using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public Enemy enemy;
    private GameObject Player;
    private float damageTaken;

    // Use this for initialization
    void Start()
    {
        damageTaken = 0;
        Player = GameObject.Find("Player");
        gameObject.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.enemyType == EnemyType.Melee)
        {
            MeleeBehavior();
        }
        else if (enemy.enemyType == EnemyType.Ranged)
        {
            RangedBehavior();
        }
        if (enemy.GetStatValue(StatsType.Health) < damageTaken)
        {
            Die();
        }
    }

    void MeleeBehavior()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemy.GetStatValue(StatsType.MovementSpeed) * Time.deltaTime);
    }

    void RangedBehavior()
    {

    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        damageTaken += amount;
    }
}
