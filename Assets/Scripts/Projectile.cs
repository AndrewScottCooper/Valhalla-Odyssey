using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject impactEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity); // play a visual hit effect
        // Destroy(effect, 5f);
        Destroy(gameObject); // destroy the projectile
        
    }

}
