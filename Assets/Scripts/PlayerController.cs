using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D playerRigidBody;
    public Camera playerCam;

    Vector2 movement; // movement direction
    // Vector2 mousePos; // mouse position

    bool canMove; // WIP for docking or menus


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");  // movement input
        movement.y = Input.GetAxisRaw("Vertical");

       // mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition); // mouse position based off of player camera
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime); // move player to new position every frame

        // rotate player to face mouse position. may remove this later.
       // Vector2 lookDirection = mousePos - playerRigidBody.position; // 
       // float turnAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; //
       // playerRigidBody.rotation = turnAngle;
    }
}
