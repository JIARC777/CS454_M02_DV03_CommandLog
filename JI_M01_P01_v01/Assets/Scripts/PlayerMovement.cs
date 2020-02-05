//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    // grab Rigidbody from Player Model for Physics
    public Rigidbody playerRB;
    // handle to control force used to move player forward
    public float zForcePerFrame = 1000f;
    // handle to control force applied to X+ and X- for strafing movement 
    public float xForcePerFrame = 100f;
    Invoker invoker;

    void Start()
    {
        invoker = new Invoker();
    }
    
    // Update is called once per frame
    void Update()
    {
        float timeCommandStarted = 0;
        float timeCommandEnded;
        float totalTimeOfCommand;
        // Use Dynamic force per frame for movement
        // Continuous forward movement system
        playerRB.AddForce(0, 0, zForcePerFrame * Time.deltaTime);

        // Handle user input for player control
        // If key "D" is pressed move right
        // Left in From AI Demo to allow full movement control in 2D space
        /*
        if (Input.GetKey("w"))
        {
            playerRB.AddForce(0, 0, zForcePerFrame * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            playerRB.AddForce(0, 0, -zForcePerFrame * Time.deltaTime, ForceMode.VelocityChange);
        }
        */
        if (Input.GetKey("d"))
		{
            // ForceMode used to ignore inertia when changing direction
            // playerRB.AddForce(xForcePerFrame * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (invoker._command != null)
                invoker.ExecuteCommand();
        }
        // if key "A" is pressed move left
        if (Input.GetKey("a"))
        {
            //playerRB.AddForce(-xForcePerFrame * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            // pass rigidbody to add force to and force to add
            // could call moveLeft.Execute() and completly skip the invoker and code should still work
            if (invoker._command != null)
                invoker.ExecuteCommand();

        }

        if (Input.GetKeyDown("d"))
        {
          //  Debug.Log("Command: Turn Right");
            Command moveRight = new MoveRight(playerRB, xForcePerFrame);
            invoker.SetCommand(moveRight, Time.timeSinceLevelLoad);
        }
        if (Input.GetKeyUp("d"))
        {
            invoker.EndCommand(Time.timeSinceLevelLoad);
        }
        if (Input.GetKeyDown("a"))
        {
          //  Debug.Log("Command: Turn Left");
            Command moveLeft = new MoveLeft(playerRB, xForcePerFrame);
            invoker.SetCommand(moveLeft, Time.timeSinceLevelLoad);
        }
        if (Input.GetKeyUp("a"))
        {
            invoker.EndCommand(Time.timeSinceLevelLoad);
        }

        if (playerRB.position.y < -1)
		{
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
 