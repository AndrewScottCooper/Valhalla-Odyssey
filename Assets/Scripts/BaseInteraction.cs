using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{

    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }

    void DockShip()
    {
        Player.transform.position = transform.position;
    }
}
