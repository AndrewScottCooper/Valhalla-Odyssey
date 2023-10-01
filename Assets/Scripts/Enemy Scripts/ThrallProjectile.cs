using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrallProjectile : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Vector2 targetpos;
    private float timeSinceShot;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetpos = new Vector2(target.position.x, target.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        timeSinceShot += Time.deltaTime;

        if (timeSinceShot > 5)
        {
            DestroyProjectile();
        }
        else if(transform.position.x == targetpos.x && transform.position.y == targetpos.y) { DestroyProjectile(); }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            //do damage to player based on attack damage and destroy the projectile
            //damage here
           // Debug.Log("HIT!");
            other.GetComponent<PlayerData>().takeDamage();
            DestroyProjectile();
        }
    }
    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
