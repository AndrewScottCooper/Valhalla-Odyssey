using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Set the player prefences at the start scene so they aren't overwritten somewhere later
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Health", 3);
            PlayerPrefs.SetInt("MaxHealth", 3);
            PlayerPrefs.SetInt("SoulsCollected", 0);
            PlayerPrefs.SetInt("Armor", 0);
            PlayerPrefs.SetInt("MaxArmor", 0);

            //Example of a way to check if an upgrade has been bought
            PlayerPrefs.SetString("Armor1", "false");
        }
        //Load data at the start of each level
        else
        {
            LoadData();
        }
          
    }

    //Double Check all changable / upgradable data types are in both save and load functions!
    public void SaveAllData()
    {
        PlayerPrefs.SetInt("Health", player.GetComponent<PlayerData>().health);
        PlayerPrefs.SetInt("MaxHealth", player.GetComponent<PlayerData>().maxHealth);
        PlayerPrefs.SetInt("SoulsCollected", player.GetComponent<PlayerData>().soulsCollected);
        PlayerPrefs.SetInt("ArrowDamage", player.GetComponent<PlayerData>().arrowDamage);
        PlayerPrefs.SetInt("Armor", player.GetComponent<PlayerData>().currArmor);
        PlayerPrefs.SetInt("MaxArmor", player.GetComponent<PlayerData>().maxHealth);

        //Example of a way to check if an upgrade has been bought
        PlayerPrefs.SetString("Armor1", "false");
    }

    public void LoadData()
    {
        player.GetComponent<PlayerData>().health = PlayerPrefs.GetInt("Health");
        player.GetComponent<PlayerData>().maxHealth = PlayerPrefs.GetInt("MaxHealth");
        player.GetComponent<PlayerData>().soulsCollected = PlayerPrefs.GetInt("SoulsCollected");
        player.GetComponent<PlayerData>().arrowDamage = PlayerPrefs.GetInt("ArrowDamage");
        player.GetComponent<PlayerData>().currArmor = PlayerPrefs.GetInt("Armor");
        player.GetComponent<PlayerData>().maxArmor = PlayerPrefs.GetInt("MaxArmor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
