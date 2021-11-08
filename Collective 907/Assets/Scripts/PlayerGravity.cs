using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float gravityStrength = 6.67384e-2f;
    // Declare a game object named planetCore
    private GameObject[] planetCore;
    // Declare characterController
    private CharacterController characterController;

    void Start(){
        // Grab the game objects with the tag "Core"
        planetCore = GameObject.FindGameObjectsWithTag("Core");
        characterController = GetComponent<CharacterController>();
    }
    
    void FixedUpdate()
    {
        // Grab the playerGravity from GravityBehavior and move this object that vector
        // Initialize a Vector3 to the zero vector
        Vector3 gravitySum = Vector3.zero;
        for (int i = 0; i < planetCore.Length; i++){
            // Add the playerGravity of the planetCore to the gravitySum
            gravitySum += planetCore[i].GetComponent<GravityBehavior>().playerGravity;
        }
        if(!characterController.isGrounded) {
            characterController.Move(gravitySum * gravityStrength);
        }
        //characterController.Move(gravitySum*6.67384e-2f);
    }
}
