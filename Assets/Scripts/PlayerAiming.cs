using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{ 

    public Rigidbody2D AimRotateRigidBody;
    public Camera playerCam;

    Vector2 mousePos; // mouse position
    public GameObject Player;


    void Update()
    {
        mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition); // mouse position based off of player camera
    }

    private void FixedUpdate()
    {
        transform.position = Player.transform.position; // move self with player position

        // rotate aimpoint to face mouse position.
        Vector2 lookDirection = mousePos - AimRotateRigidBody.position; // 
        float turnAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; //
        AimRotateRigidBody.rotation = turnAngle;
    }
}
