using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerUI PlayerUIManager;

    public int health;
    public int maxHealth;
    public int currArmor;
    public int maxArmor;

    public int soulsCollected;


    public int arrowDamage;

    // Start is called before the first frame update
    void Start()
    {
        PlayerUIManager.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //should be updated to take the amount of damage from a specific enemy type later if we change this
    public void takeDamage()
    {
        if (currArmor == 0)
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            currArmor -= 1; 
        }
        PlayerUIManager.UpdateHealthBar();
    }
}