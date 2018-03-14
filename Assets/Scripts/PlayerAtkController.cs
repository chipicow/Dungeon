using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkController : MonoBehaviour
{
    public GameObject projectileObject;
    float fireRate;
    float bulletSpeed;
    private float time;
    void Start()
    {
        fireRate = PlayerStats.instance.GetStatValue(StatsType.AttackCooldown);
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && time >= fireRate)
        {
            fireRate = PlayerStats.instance.GetStatValue(StatsType.AttackCooldown);
            bulletSpeed = PlayerStats.instance.GetStatValue(StatsType.ProjectileSpeed);
            time = 0f;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    projectileObject,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);
            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
