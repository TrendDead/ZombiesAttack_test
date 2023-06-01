using System;
using UnityEngine;

public class TouchInput : MonoCache, IPlayerInput
{
    public event Action<Vector2> InputVecror;

    private Transform _playerTransform;

    public void Init(Transform playerTransform) => _playerTransform = playerTransform;

    public override void Run()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if(_playerTransform != null)
            {
                InputVecror?.Invoke(worldPosition - _playerTransform.position);
            }
        }
    }
}
