using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoCache
{
    [SerializeField]
    private float _speed = 40f;

    private Vector3 _startPosition;
    private Vector3 _targgetPosition;
    private float _progress;

    private void Start()
    {
        _startPosition = transform.position.WithAxis(Axis.z, -1);
    }
    public override void Run()
    {
        _progress += Time.deltaTime * _speed;
        transform.position = Vector3.Lerp(_startPosition, _targgetPosition, _progress);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targgetPosition = targetPosition.WithAxis(Axis.z, -1);
    }
}
