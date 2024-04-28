using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _bulletRigidbody;

    public Rigidbody Rigidbody { get => _bulletRigidbody; set => _bulletRigidbody = value; }

    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }
}