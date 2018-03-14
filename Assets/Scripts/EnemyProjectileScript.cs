using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public Enemy enemy;
    void Start()
    {
        Destroy(gameObject, enemy.GetStatValue(StatsType.ProjectileRange) / enemy.GetStatValue(StatsType.ProjectileSpeed));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
