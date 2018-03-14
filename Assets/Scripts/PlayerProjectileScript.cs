using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, PlayerStats.instance.GetStatValue(StatsType.ProjectileRange) / PlayerStats.instance.GetStatValue(StatsType.ProjectileSpeed));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        if (col.collider.gameObject.layer == 9)
        {
            Vector2 knockbackPosition = col.gameObject.transform.position + (col.gameObject.transform.position - transform.position).normalized * PlayerStats.instance.GetStatValue(StatsType.KnockBackForce);
            StartCoroutine(col.gameObject.GetComponent<EnemyBehavior>().GetKnockBack(knockbackPosition, PlayerStats.instance.GetStatValue(StatsType.KnockBackDuration)));
            col.gameObject.GetComponent<EnemyBehavior>().TakeDamage(PlayerStats.instance.GetStatValue(StatsType.Damage));
            Destroy(gameObject);
        }

        if (col.collider.gameObject.layer == 10)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
