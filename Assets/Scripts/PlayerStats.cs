using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singleton
    public static PlayerStats instance;


    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject Player;
    public List<CharacterStat> allStats;

    private float DamageTaken;
    Animation animationList;
    void Start()
    {
        DamageTaken = 0;
        animationList = Player.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetStatValue(StatsType.Health) <= DamageTaken)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("took more then health value: " + GetStatValue(StatsType.Health) + " " + DamageTaken);
    }

    public void TakeDamage(float amount)
    {
        DamageTaken += amount * (1 - GetStatValue(StatsType.Armor));
        animationList.Play("KnockBackRed");
    }

    public float GetStatValue(StatsType type)
    {
        return allStats.Find(x => x.StatType == type).Value;
    }

    public float DealDamage()
    {
        float damage = GetStatValue(StatsType.Damage);
        if (Random.value <= GetStatValue(StatsType.CriticalChance))
        {
            damage *= GetStatValue(StatsType.CriticalDamage);
        }
        DamageTaken = System.Math.Max(0, DamageTaken - GetStatValue(StatsType.OnHitDrain));
        return (float)System.Math.Round(damage, 0);
    }

}
