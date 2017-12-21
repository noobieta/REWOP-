using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    public bool Freeze = false;

    public float moveSpeed = 16.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;

    public VirtualJoystick joystick;
    private Rigidbody controller;


    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = terminalRotationSpeed;
        controller.drag = drag;
    }

    private Vector3 lastdir = Vector3.zero;
    private void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;

        if (!Freeze)
        {
            dir.x = joystick.Horizontal();//Input.GetAxis("Horizontal"); 
            dir.z = joystick.Vertical();// Input.GetAxis("Vertical");
        }

        if (dir != Vector3.zero)
        {
            lastdir = dir;
            this.transform.rotation = Quaternion.LookRotation(lastdir);
        }
       
        if (dir.magnitude > 1)
            dir.Normalize();
        controller.AddForce(dir * moveSpeed);


        //check if player getoutofbounds
        if (transform.position.y < 0)
        {
            Debug.Log("Player died: Out of Game Bounds!");
            PlayerManager.instance.KillPlayer();
        }

    }
}
