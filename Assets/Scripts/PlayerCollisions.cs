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
            Debug.Log("player collided with monster");
            timeSpent = 0f;
            var enemyComponent = col.gameObject.GetComponent<EnemyBehavior>();
            Vector2 knockbackPosition = transform.position + (transform.position - col.transform.position).normalized * enemyComponent.enemy.GetStatValue(StatsType.KnockBackForce);
            StartCoroutine(gameObject.GetComponent<PlayerMovement>().GetKnockBack(knockbackPosition, enemyComponent.enemy.GetStatValue(StatsType.KnockBackDuration),transform));
            PlayerStats.instance.TakeDamage(enemyComponent.enemy.GetStatValue(StatsType.Damage));
        }
    }
}
