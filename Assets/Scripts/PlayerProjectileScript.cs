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
            col.gameObject.GetComponent<EnemyBehavior>().TakeDamage(PlayerStats.instance.GetStatValue(StatsType.Damage));
            Destroy(gameObject);
        }
    }
}
