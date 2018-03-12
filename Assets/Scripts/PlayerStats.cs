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

    public CharacterStat Health;
    public CharacterStat Damage;
    public CharacterStat MovementSpeed;
    public CharacterStat AttackCooldown;
    public CharacterStat ProjectileRange;
    public CharacterStat ProjectileSpeed;

    private float DamageTaken;
    void Start()
    {
        DamageTaken = 0;
        Health.BaseValue = 3;
        Damage.BaseValue = 1;
        MovementSpeed.BaseValue = 5;
        AttackCooldown.BaseValue = 0.2f;
        ProjectileRange.BaseValue = 5f;
        ProjectileSpeed.BaseValue = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.Value <= DamageTaken)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("took more then health value: " + Health.Value + " " + DamageTaken);
    }

    public void TakeDamage(float amount)
    {
        DamageTaken += amount;
    }
}
