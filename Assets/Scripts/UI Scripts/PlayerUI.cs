using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;

    public List<Image> HealthBar;
    public List<Sprite> HealthIcons;

   public void UpdateHealthBar()
    {
        //if armor was taken away or health restored resting the base images will undo those
        ResetHearts();
       
        for (int i = 0; i < player.GetComponent<PlayerData>().maxHealth; i++)
        {
            if(i < player.GetComponent<PlayerData>().maxHealth)
            {
                Image temp = HealthBar[i];
                temp.enabled = true;
            }  
            //the current slot is armored change the icon to be armored
            if (player.GetComponent<PlayerData>().currArmor > 0 && player.GetComponent<PlayerData>().currArmor > i)
            {
                HealthBar[i].sprite = HealthIcons[2];
            }
            //if the value of the player health is less than the max number of health bars and the index is higher than the current health, set the heart to
            //empty health icon
            else if (player.GetComponent<PlayerData>().health < player.GetComponent<PlayerData>().maxHealth && i >= player.GetComponent<PlayerData>().health)
            {
                HealthBar[i].sprite = HealthIcons[1];
            }
            
        }
    }
    public void ResetHearts()
    {
        foreach(Image image in HealthBar)
        {
            image.sprite = HealthIcons[0];
        }
    }

}
