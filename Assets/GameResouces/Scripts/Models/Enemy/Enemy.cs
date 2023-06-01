using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    public EnemyConfig Config { get; private set; }

    [SerializeField]
    private SpriteRenderer _enemySprite;
    [SerializeField]
    private EnemyView _enemyView;

    private UnitMover _unitMover;
    private UnitRotator _enemyRotator;
    private float _health;
    private float _speed;
    private float _maxHP;

    public void Init(EnemyConfig enemyConfig)
    {
        Config = enemyConfig;

        _maxHP = _health = enemyConfig.MaxHealth;
        _speed = enemyConfig.UnitsPerSecond;
        _enemySprite.sprite = enemyConfig.EnemySprite;
        _enemyView.UpdateView(1);
    }

    public void MoveToTargget(Transform targget)
    {
        _enemyRotator = new UnitRotator(transform);
        _enemyRotator.Rotate(targget.position - transform.position);
        _unitMover = new UnitMover(transform, _speed);
        _unitMover.Move(targget.transform.position - transform.position);
    }

    public void GetDamage(float addDamage)
    {
        _health -= addDamage;

        _enemyView.UpdateView(_health / _maxHP);
        if (_health <= 0)
        {
            //можно добавить звук

            gameObject.SetActive(false);
        }
    }

    public void ReceiveHit(float damage)
    {
        GetDamage(damage);
    }

    public bool IsDestroy()
    {
        return !gameObject.activeSelf;
    }
}

public enum EnemyTipe
{
    ZombiePrivate,
    ZombieSeasoned,
    ZombieArmored
}
