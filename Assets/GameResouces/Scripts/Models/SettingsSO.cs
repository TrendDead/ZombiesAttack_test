using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "ZombiesAttack/New Settings")]
public class SettingsSO : ScriptableObject
{
    [Header("Enemy Spawn Settings")]
    public float StartTimeSpawn = 2f;
    public float MinStartTimeSpawn = 0.5f;
    public float ComplicationTime = 10f;
    public float SpawnTimeReduction = 0.1f;
    public int NumberOfSpawningZombies = 1;

    [Header("Player Settings")]
    public float PlayerDamage = 1;
    public int PlayerShotPerSeconds = 10;

    [Header("General Settings")]
    public int InputSystemType = 0;

}
