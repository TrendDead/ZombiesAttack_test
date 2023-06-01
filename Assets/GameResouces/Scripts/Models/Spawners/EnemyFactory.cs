using UnityEngine;

public abstract class EnemyFactory : ScriptableObject
{
    public Enemy GetRandom(float percent)
    {
        EnemyConfig[] enemyConfigs = GetAllConfig();

        float localPercent = 0f;

        for (int i = 0; i < enemyConfigs.Length; i++)
        {
            localPercent += enemyConfigs[i].PercentToSpawn;
            if (localPercent > percent) 
            {
                return Get(enemyConfigs[i]);
            }
            if (localPercent > 100)
            {
                Debug.LogError($"The total chance of enemies spawning is over 100%");
            }
        }

        Debug.LogError($"The total chance of enemies spawning is less than 100%");
        return Get(enemyConfigs[0]);
    }

    public Enemy Get(EnemyTipe enemyTipe)
    {
        var config = GetConfig(enemyTipe); 
        return Get(config);
    }    
    
    public Enemy Get(EnemyConfig config)
    {
        Enemy instance = config.EnemyPrefab;
        instance.Init(config);
        return instance;
    }

    protected abstract EnemyConfig GetConfig(EnemyTipe enemyTipe);
    protected abstract EnemyConfig[] GetAllConfig();
}
