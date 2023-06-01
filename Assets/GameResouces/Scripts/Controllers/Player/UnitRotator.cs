using UnityEngine;

public class UnitRotator
{
    private readonly Transform _transform;

    private float _offset = -90;

    public UnitRotator(Transform transform)
    {
        _transform = transform;
    }

    public void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero && !GameManager.Instance.IsRun) return;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(0, 0, angle + _offset);
    }
}
