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
        //get reference to how much damage the player's arrows do just incase we add damage upgrades
        damage = player.GetComponent<PlayerData>().arrowDamage;        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //only do damage to enemies if we hit something tagged as an enemy
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyData>().TakeDamage(damage);
            Destroy(gameObject);
            // ~~ ~~ WHENEVER we add an impact visual effect we can use this ~~ ~~ //
            // GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity); // play a visual hit effect
            // Destroy(effect, 5f);\
        }
        else if (collision.collider.CompareTag("Environment"))
        {
            Destroy(gameObject);
            // ~~ ~~ WHENEVER we add an impact visual effect we can use this ~~ ~~ //
            // GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity); // play a visual hit effect
            // Destroy(effect, 5f);\
        }

    }

}
