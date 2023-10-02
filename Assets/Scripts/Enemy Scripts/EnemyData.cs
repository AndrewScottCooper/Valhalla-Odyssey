using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public EnemyType hostileType;
    public GameObject soulDrop;

    public int Health;
    public int MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //removes health from the enemy, if no health kill the enemy
    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        if(Health <= 0)
        {
           Instantiate(soulDrop, transform.position,quaternion.identity);
          Destroy(gameObject);
        }

    }

    public enum EnemyType
    {
        EldritchThrall,
        EldritchThrallV2,
        EldritchThrallV3,
        Boss1,
        Boss2, 
        Boss3

    }
}
