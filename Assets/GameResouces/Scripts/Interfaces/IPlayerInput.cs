using System;
using UnityEngine;

public interface IPlayerInput
{
    public event Action<Vector2> InputVecror;
    public void Init(Transform playerTransform);
}
