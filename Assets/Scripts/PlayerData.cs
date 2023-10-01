using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public int arrowDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        health -= 1;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
