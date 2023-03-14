using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnLocation;
    public float maxProjectileForce = 1000f;
    public float minProjectileForce = 100f;

    private float currentProjectileForce;
    private float chargeDuration;
    private bool isProjectileCharging;

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnLocation.position, spawnLocation.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(spawnLocation.forward * currentProjectileForce, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Fire1")){
       
        }
    } 
}
