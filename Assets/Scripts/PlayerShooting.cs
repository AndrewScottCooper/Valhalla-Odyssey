using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform aimPoint;
    public GameObject ProjectilePrefab;

    public float arrowFireRate = 0.5f; //fire rate in seconds
    public float arrowProjectileForce = 20f; //arrow travel speed

    float arrowCooldown = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (arrowCooldown >= arrowFireRate)
                Shoot(); 
        }
        arrowCooldown += Time.deltaTime;
    }

    void Shoot()
    {
        
        GameObject Projectile = Instantiate(ProjectilePrefab, aimPoint.position, aimPoint.rotation);
        Rigidbody2D ProjectileRigidBody = Projectile.GetComponent<Rigidbody2D>();
        ProjectileRigidBody.AddForce(aimPoint.up * arrowProjectileForce, ForceMode2D.Impulse);
        arrowCooldown = 0f;

    }
}
