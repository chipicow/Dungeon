using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, PlayerStats.instance.ProjectileRange.Value / PlayerStats.instance.ProjectileSpeed.Value);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        if (col.collider.gameObject.layer == 9)
        {
            col.gameObject.GetComponent<EnemyBehavior>().TakeDamage(PlayerStats.instance.Damage.Value);
            Destroy(gameObject);
        }
    }
}
