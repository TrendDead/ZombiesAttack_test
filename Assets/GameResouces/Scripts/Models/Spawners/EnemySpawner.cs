using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyFactory _enemyFactory;
    [SerializeField]
    private Transform _enemySpawnParent;

    private List<Enemy> _enemies = new List<Enemy>();
    private Transform _targetTransfor;
    private float _timeSpawn;
    private float _minStartTimeSpawn;
    private float _complicationTime;
    private float _spawnTimeReduction;
    private int _numberOfSpawningZombies;


    public void StartSpawn(SettingsSO settings, Transform targetTransfor)
    {
        _numberOfSpawningZombies = settings.NumberOfSpawningZombies;
        _timeSpawn = settings.StartTimeSpawn;
        _minStartTimeSpawn = settings.MinStartTimeSpawn;
        _complicationTime = settings.ComplicationTime;
        _spawnTimeReduction = settings.SpawnTimeReduction;

        _targetTransfor = targetTransfor;

        StartCoroutine(SpawnTimer());
        StartCoroutine(ComplicationTimer());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnTimer()
    {
        while (true) 
        {
            for (int i = 0; i < _numberOfSpawningZombies; i++)
            {
                Spawn();
            }

            yield return new WaitForSeconds(_timeSpawn);
        }
    }    
    
    private void Spawn()
    {
        float enemyChance = Random.Range(0f, 100f);

        Enemy enemyPrefab = _enemyFactory.GetRandom(enemyChance);

        foreach (var enemy in _enemies)
        {
            if(!enemy.gameObject.activeSelf)
            {
                enemy.gameObject.SetActive(true);
                enemy.Init(enemyPrefab.Config);
                enemy.transform.position = GetRandomSpawnPosition();
                enemy.MoveToTargget(_targetTransfor);

                return;
            }
        }

        var newEnemy = Instantiate(enemyPrefab, _enemySpawnParent);
        newEnemy.Init(enemyPrefab.Config);
        newEnemy.transform.position = GetRandomSpawnPosition();
        newEnemy.MoveToTargget(_targetTransfor);

        _enemies.Add(newEnemy);


    }

    private Vector2 GetRandomSpawnPosition()
    {
        var _frameCoordinates = ScreenSize.GetCornerCoordinates();

        int isHorizontalSpawn = Random.Range(-1, 2);
        float x = isHorizontalSpawn != 0 ? (_frameCoordinates.PointUR.x + 1f) * isHorizontalSpawn : Random.Range(_frameCoordinates.PointBL.x, _frameCoordinates.PointUR.x);
        float y = isHorizontalSpawn != 0 ? Random.Range(_frameCoordinates.PointBL.y + 1f, _frameCoordinates.PointUR.y) : _frameCoordinates.PointUR.y + 1f;

        return new Vector2(x, y);
    }

    private IEnumerator ComplicationTimer()
    {
        var timer = new WaitForSeconds(_complicationTime);
        while (_timeSpawn > _minStartTimeSpawn)
        {
            yield return timer;

            _timeSpawn -= _spawnTimeReduction;
        }
    }
}
