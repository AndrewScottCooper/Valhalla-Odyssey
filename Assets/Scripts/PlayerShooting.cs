using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform aimPoint;
    public GameObject ProjectilePrefab;

    public float ProjectileForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject Projectile = Instantiate(ProjectilePrefab, aimPoint.position, aimPoint.rotation);
        Rigidbody2D ProjectileRigidBody = Projectile.GetComponent<Rigidbody2D>();
        ProjectileRigidBody.AddForce(aimPoint.up * ProjectileForce, ForceMode2D.Impulse);
    }
}
