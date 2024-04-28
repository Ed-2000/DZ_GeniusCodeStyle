using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _waitingTimeBetweenShots;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        var wait = new WaitForSeconds(_waitingTimeBetweenShots);

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bullet, transform.position, Quaternion.identity);

            Rigidbody bulletRigidbody = newBullet.Rigidbody;
            bulletRigidbody.transform.up = direction;
            bulletRigidbody.velocity = direction * _bulletSpeed;

            yield return wait;
        }
    }
}