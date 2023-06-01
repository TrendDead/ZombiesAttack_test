using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerPrefab;

    public PlayerController Spawn()
    {
        FrameCoordinates _chamberDimensions = ScreenSize.GetCornerCoordinates();
        Vector3 spawnPosition = new Vector3((_chamberDimensions.PointUR.x + _chamberDimensions.PointBL.x) / 2, _chamberDimensions.PointBL.y + (_playerPrefab.transform.localScale.y / 2), 0f);
        var player = Instantiate(_playerPrefab, spawnPosition, Quaternion.identity);
        return player;
    }
}
