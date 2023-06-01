using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralEnemyFactory", menuName = "ZombiesAttack/New GeneralEnemyFactory")]
public class GeneralEnemyFactory : EnemyFactory
{
    [SerializeField]
    private EnemyConfig _private, _seasoned, _armored;

    protected override EnemyConfig[] GetAllConfig()
    {
        EnemyConfig[] enemyConfigs = new EnemyConfig[3]
        {
            _private,
            _seasoned,
            _armored
        };

        return enemyConfigs;
    }

    protected override EnemyConfig GetConfig(EnemyTipe enemyTipe)
    {
        switch (enemyTipe)
        {
            case EnemyTipe.ZombiePrivate:
                return _private;
            case EnemyTipe.ZombieSeasoned:
                return _seasoned;
            case EnemyTipe.ZombieArmored:
                return _armored;
        }
        Debug.LogError($"No config for: {enemyTipe}");
        return _private;
    }

}
