using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public float bulletForce = 100f;
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(transform.up * bulletForce, ForceMode.Impulse);

        Invoke("DestroyProjectile", 5f);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}