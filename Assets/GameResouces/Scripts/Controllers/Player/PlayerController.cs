using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shoot Settings")]
    [SerializeField]
    private PlayerShooter _playerShooter;

    private float _damage;
    private int _shotPerSecond;

    private UnitRotator _playerRotator;
    private IPlayerInput _playerInput;

    public void Init(IPlayerInput inputSystem, SettingsSO settings)
    {
        _playerInput = inputSystem;
        _playerInput.Init(this.transform);
        _playerRotator = new UnitRotator(this.transform);
        _playerInput.InputVecror += _playerRotator.Rotate;

        _damage = settings.PlayerDamage;
        _shotPerSecond = settings.PlayerShotPerSeconds;

        _playerShooter.StartShot(_damage, _shotPerSecond);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy)) 
        {
            GameManager.Instance.GameOver();
        }
    }

}
