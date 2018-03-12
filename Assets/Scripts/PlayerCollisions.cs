using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 9)
        {
            PlayerStats.instance.TakeDamage(col.gameObject.GetComponent<Enemy>().statList.Find(x=>x.StatType == StatsType.Damage).Value);
        }
    }
}
