using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public PlayerUI PlayerUIManager;

    public int health;
    public int maxHealth;
    public int currArmor;
    public int maxArmor;

    public int soulsCollected;


    public int arrowDamage;
    public float damageTime = 0.5f; // time in seconds player is invulnerable after being hit
    float damageTimeReset = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        PlayerUIManager.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        damageTimeReset += Time.deltaTime;
    }

    //should be updated to take the amount of damage from a specific enemy type later if we change this
    public void takeDamage()
    {
        if (damageTimeReset > damageTime) { 
            if (currArmor == 0)
            {
                health -= 1;
                if (health <= 0)
                {
                    //Destroy(gameObject);
                    SceneManager.LoadScene("Valhalla"); //zack
                }
            }
            else
            {
                currArmor -= 1; 
            }
            PlayerUIManager.UpdateHealthBar();
            damageTimeReset = 0f;
        }
    }
}
