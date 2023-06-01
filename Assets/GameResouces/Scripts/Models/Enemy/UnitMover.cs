using System;
using UnityEngine;

public class UnitMover
{
    public event Action<Vector3> PlayerMoved;
    private Rigidbody2D _rigidbody;
    private float _speed;

    public UnitMover(Transform transform, float speed)
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        _speed = speed;
    }

    public void Move(Vector2 inputValues)
    {
        _rigidbody.velocity = (inputValues.normalized * _speed);
    }
}
