using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public Enemy enemy;
    private float damageTaken;
    EnemyType enemyType;
    GameObject Player;
    float time;


    // Use this for initialization
    void Start()
    {
        damageTaken = 0;
        Player = PlayerStats.instance.Player;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
        enemyType = enemy.enemyType;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyType == EnemyType.Melee)
        {
            MeleeBehavior();
        }
        else if (enemyType == EnemyType.Ranged)
        {
            RangedBehavior();
        }
        if (enemy.GetStatValue(StatsType.Health) <= damageTaken)
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
        FollowOrMoveAwayFromPlayer();

        ShootAtPlayer();
    }

    void FollowOrMoveAwayFromPlayer()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) > enemy.GetStatValue(StatsType.StoppingDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemy.GetStatValue(StatsType.MovementSpeed) * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Player.transform.position) <= enemy.GetStatValue(StatsType.StoppingDistance) && Vector2.Distance(transform.position, Player.transform.position) > enemy.GetStatValue(StatsType.RetreatDistance))
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Player.transform.position) < enemy.GetStatValue(StatsType.RetreatDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -enemy.GetStatValue(StatsType.MovementSpeed) * Time.deltaTime);
        }
    }

    void ShootAtPlayer()
    {
        time += Time.deltaTime;
        if (time >= enemy.GetStatValue(StatsType.AttackCooldown))
        {
            time = 0f;
            Vector3 worldMousePos = Player.transform.position;
            Vector2 direction = ((worldMousePos - transform.position)).normalized;
            var projectile = Instantiate(enemy.monsterProjectile, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);
            projectile.GetComponent<EnemyProjectileScript>().enemy = enemy;
            projectile.transform.localScale += new Vector3(projectile.transform.localScale.x, projectile.transform.localScale.y, 0) * enemy.GetStatValue(StatsType.ProjectileSize);
            // Adds velocity to the bullet
            projectile.GetComponent<Rigidbody2D>().velocity = direction * enemy.GetStatValue(StatsType.ProjectileSpeed);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        damageTaken += amount;
        GetComponent<Animation>().Play("KnockBackRed");
    }

    public IEnumerator GetKnockBack(Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}
