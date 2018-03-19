using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Name", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public List<CharacterStat> statList = new List<CharacterStat>() { new CharacterStat() { StatType = StatsType.Armor, BaseValue = 0}, new CharacterStat() { StatType = StatsType.Health, BaseValue = 0 }, new CharacterStat() { StatType = StatsType.MovementSpeed, BaseValue = 0 }, new CharacterStat() { StatType = StatsType.Damage, BaseValue = 0 }, new CharacterStat() { StatType = StatsType.KnockBackForce, BaseValue = 0 }, new CharacterStat() { StatType = StatsType.KnockBackDuration, BaseValue = 0 } };
    public EnemyType enemyType;
    public Sprite enemySprite;
    public GameObject monsterProjectile;
    public float GetStatValue(StatsType type)
    {
        Debug.Log(GetStatValue(StatsType.Armor));
        return statList.Find(x => x.StatType == type).Value;
    }
}

public enum EnemyType
{
    Melee,
    Ranged
}
