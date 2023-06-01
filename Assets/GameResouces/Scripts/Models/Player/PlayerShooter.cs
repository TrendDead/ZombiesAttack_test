using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private const int MaxDistanceShoot = 50;

    [SerializeField]
    private Transform _gunPoint;
    [SerializeField]
    private BulletTrail _bulletTrail;
    //[SerializeField]
    //private Animator _animator;

    private float _damageDeal;
    private int _roundsPerSecond;

    public void StartShot(float strange, int roundsPerSecond)
    {
        _damageDeal = strange;
        _roundsPerSecond = roundsPerSecond;
        StartCoroutine(ShootTimer());
    }

    public void StopShoot()
    {
        StopAllCoroutines();
    }

    private IEnumerator ShootTimer() 
    { 
        var timer = new WaitForSeconds(1f / _roundsPerSecond);
        while (true)
        {
            Shoot();

            yield return timer; 
        }
    }

    private void Shoot()
    {
        //Добавить визуальноу и звуковое сопровождение выстрела


        //RaycastHit2D hit = Physics2D.Raycast(_gunPoint.position, (_gunPoint.position - transform.position).normalized, _MaxDistanceShoot);
        RaycastHit2D hit = Physics2D.Raycast(_gunPoint.position, transform.up, MaxDistanceShoot);

        var trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);

        if (hit.collider != null)
        {
            trail.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();

            if (hittable != null)
            {
                hittable.ReceiveHit(_damageDeal);
                if (hittable.IsDestroy())
                {
                    if (hit.transform.TryGetComponent(out Enemy enemy))
                    {
                        GameManager.Instance.AddScore(enemy.Config.Score);
                    }
                }
            }
            
        }
        else
        {
            var endPosition = _gunPoint.position + transform.up * MaxDistanceShoot;
            trail.SetTargetPosition(endPosition);
        }

    }
}
