using System;
using UnityEngine;

[Serializable]
public class EnemyConfig
{
    public Enemy EnemyPrefab;
    public Sprite EnemySprite;
    public float MaxHealth;
    public float UnitsPerSecond;
    public float PercentToSpawn;
    public int Score;
}
