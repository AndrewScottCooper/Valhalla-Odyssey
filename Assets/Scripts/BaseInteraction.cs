using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{

    public GameObject player;
    public GameObject playerAimPoint;

    public bool playerDocked;
    public Rigidbody2D rb;

    public bool keyReset = true; // we NEED this becuase OnTriggerStay2D doesnt occur every Update() reliably.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            keyReset = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if (collision.GetComponent<Rigidbody2D>().CompareTag("Player"))
        {
            //Debug.Log("touching player");
            if (Input.GetButton("Submit"))
            {
                
                DockShip();
                keyReset = false;
            }
        }
    }

    void DockShip()
    {
        if (!playerDocked && keyReset) {
            player.GetComponent<PlayerController>().canMove = false;
            playerAimPoint.GetComponent<PlayerShooting>().canShoot = false;
            playerDocked = true;
            player.transform.position = transform.position;


        }
        else if (playerDocked && keyReset)
        {
            player.GetComponent<PlayerController>().canMove = true;
            playerAimPoint.GetComponent<PlayerShooting>().canShoot = true;
            playerDocked = false;
            player.transform.position = rb.position + Vector2.down; ;
        }

    }
}
