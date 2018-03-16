using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Name", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public List<CharacterStat> statList;
    public EnemyType enemyType;
    public Sprite enemySprite;
    public GameObject monsterProjectile;
    public float GetStatValue(StatsType type)
    {
        return statList.Find(x => x.StatType == type).Value;
    }
}

public enum EnemyType
{
    Melee,
    Ranged
}
