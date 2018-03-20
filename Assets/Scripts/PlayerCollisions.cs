using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public float invinciblePeriod;
    private float timeSpent = 0;
    void Start()
    {

    }

    void Update()
    {
        timeSpent += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == 9 && timeSpent >= invinciblePeriod)
        {
            timeSpent = 0f;
            var enemyComponent = col.gameObject.GetComponent<EnemyBehavior>();
            Vector2 knockbackPosition = transform.position + (transform.position - col.transform.position).normalized * enemyComponent.enemy.GetStatValue(StatsType.KnockBackForce);
            StartCoroutine(gameObject.GetComponent<PlayerMovement>().GetKnockBack(knockbackPosition, enemyComponent.enemy.GetStatValue(StatsType.KnockBackDuration)));
            PlayerStats.instance.TakeDamage(enemyComponent.enemy.GetStatValue(StatsType.Damage));
            if (PlayerStats.instance.GetStatValue(StatsType.Melee) > 0)
                enemyComponent.TakeDamage(PlayerStats.instance.GetStatValue(StatsType.Melee));
        }
        //gotta debate wheter i destroy the projectile if player is  inmune
        if (col.gameObject.layer == 10)
        {
            if (timeSpent >= invinciblePeriod)
            {
                var enemyStats = col.gameObject.GetComponent<EnemyProjectileScript>().enemy;
                Vector2 knockbackPosition = transform.position + (transform.position - col.transform.position).normalized * enemyStats.GetStatValue(StatsType.KnockBackForce);
                StartCoroutine(gameObject.GetComponent<PlayerMovement>().GetKnockBack(knockbackPosition, enemyStats.GetStatValue(StatsType.KnockBackDuration)));
                PlayerStats.instance.TakeDamage(enemyStats.GetStatValue(StatsType.Damage));
            }
            Destroy(col.gameObject);
        }
    }
}
