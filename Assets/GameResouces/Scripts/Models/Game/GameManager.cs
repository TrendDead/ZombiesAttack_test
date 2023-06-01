using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsRun { get; private set; }


    [SerializeField]
    private SpawnerPlayer _spawnerPlayer;
    [SerializeField]
    private PlayerInputSelecter _playerInputSelecter;
    [SerializeField]
    private SettingsSO _settingsSO;
    [SerializeField]
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private GameOverPunel _gameOverPunel;
    [SerializeField]
    private CameeraSizeController _cameeraSizeController;

    private float _score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        IsRun = true;
        _cameeraSizeController.ChangeCameraSize();
        var player = _spawnerPlayer.Spawn();
        player.Init(_playerInputSelecter.GetInoutSystem(_settingsSO.InputSystemType), _settingsSO);
        _enemySpawner.StartSpawn(_settingsSO, player.transform);
    }

    public void AddScore(float addScore)
    {
        _score += addScore;
    }

    public void GameOver()
    {
        IsRun = false;
        Time.timeScale = 0f;
        if(Loader.MaxScore < _score)
            Loader.MaxScore = _score;
        _gameOverPunel.gameObject.SetActive(true);
        _gameOverPunel.Init(_score);
    }
}
