using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public GameObject impactEffect;
    public GameObject player;

    private void Start()
    {
        damage = player.GetComponent<PlayerData>().arrowDamage;        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity); // play a visual hit effect
        // Destroy(effect, 5f);\
        if (collision.collider.CompareTag("ThrallV1"))
        {
          collision.gameObject.GetComponent<EnemyData>().TakeDamage(damage);
        }
        Destroy(gameObject); // destroy the projectile
        
    }

}
