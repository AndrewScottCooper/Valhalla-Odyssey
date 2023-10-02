using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;

    public List<Image> HealthBar;
    public List<Sprite> HealthIcons;

    public int healthSoulCost;
    public int armorSoulCost;
    public int arrowUpgradeCost;

    public TMPro.TMP_Text soulLabel;

    public CanvasGroup meadhallGroup;
    public CanvasGroup shipyardGroup;
    public CanvasGroup bowyerGroup;
    public CanvasGroup blacksmithGroup;

    private void Start()
    {
        //make sure labels aren't default on level loading
        UpdateHealthBar();
        UpdateSoulLabel();
    }

    public void UpdateHealthBar()
    {
        //if armor was taken away or health restored resting the base images will undo those
        ResetHearts();
       
        for (int i = 0; i < player.GetComponent<PlayerData>().maxHealth; i++)
        {
            Image temp = HealthBar[i];
            if (i < player.GetComponent<PlayerData>().maxHealth)
            {
                
                temp.enabled = true;
            }  
            //the current slot is armored change the icon to be armored
            if (player.GetComponent<PlayerData>().currArmor > 0 && player.GetComponent<PlayerData>().currArmor > i)
            {
                HealthBar[i].sprite = HealthIcons[2];
            }
            //if the value of the player health is less than the max number of health bars and the index is higher than the current health, set the heart to
            //empty health icon
            else if (player.GetComponent<PlayerData>().health < player.GetComponent<PlayerData>().maxHealth && i  >= player.GetComponent<PlayerData>().health)
            {
                HealthBar[i].sprite = HealthIcons[1];
            }
            else if(i >= player.GetComponent<PlayerData>().maxHealth)
            {
                temp.enabled = false;
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

    public void UpdateSoulLabel()
    {
        soulLabel.text = "Souls Saved: " + player.GetComponent<PlayerData>().soulsCollected.ToString();
    }

    //Check if current max health is less than our hard limit, and if player can afford it. Then add the extra health and deduct the soul cost.
    public void UpgradeHealth()
    {
        if (player.GetComponent<PlayerData>().maxHealth < 5 && player.GetComponent<PlayerData>().soulsCollected >= healthSoulCost) {

            player.GetComponent<PlayerData>().maxHealth += 1;
            player.GetComponent<PlayerData>().soulsCollected -= healthSoulCost;
            UpdateSoulLabel();
        }
        UpdateHealthBar();
    }
    public void Upgradearmor()
    {
        if (player.GetComponent<PlayerData>().maxArmor < 2 && player.GetComponent<PlayerData>().soulsCollected >= armorSoulCost)
        {

            player.GetComponent<PlayerData>().maxArmor += 1;
            player.GetComponent<PlayerData>().soulsCollected -= armorSoulCost;
            UpdateSoulLabel();
        }
        UpdateHealthBar();
    }
    //repairs player health and armor
    public void RepairPlayer()
    {
        player.GetComponent<PlayerData>().health = player.GetComponent<PlayerData>().maxHealth;
        player.GetComponent<PlayerData>().currArmor = player.GetComponent<PlayerData>().maxArmor;
        UpdateHealthBar();
    }
    //upgrade the amount of damage done by arrows by 1, up to level 3
    public void UpgradeArrowDamage()
    {
        if (player.GetComponent<PlayerData>().arrowDamage < 3 && player.GetComponent<PlayerData>().soulsCollected >= arrowUpgradeCost)
        {

            player.GetComponent<PlayerData>().arrowDamage += 1;
            player.GetComponent<PlayerData>().soulsCollected -= arrowUpgradeCost;
            UpdateSoulLabel();
        }
    }
  

    /// <summary>
    /// Methods for switching menues in buildings for the Valhalla level
    /// </summary>
    /// 
    public void MeadHallDisplay()
    {
        meadhallGroup.gameObject.SetActive(!meadhallGroup.gameObject.activeSelf);
    }
    public void ShipyardDisplay()
    {
        shipyardGroup.gameObject.SetActive(!shipyardGroup.gameObject.activeSelf);
    }
    public void BowyerDisplay()
    {
        bowyerGroup.gameObject.SetActive(!bowyerGroup.gameObject.activeSelf);
    }
    public void BlacksmithDisplay()
    {
        blacksmithGroup.gameObject.SetActive(!blacksmithGroup.gameObject.activeSelf);
    }


}
