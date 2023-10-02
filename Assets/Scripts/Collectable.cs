using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //add soul to the player, and update the UI
            other.GetComponent<PlayerData>().soulsCollected++;
            other.GetComponent<PlayerData>().PlayerUIManager.UpdateSoulLabel();
            Destroy(gameObject);
        }
    }
}
