using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    // Declare a game object named planetCore
    private GameObject[] planetCore;
    // Declare characterController
    private CharacterController characterController;
    void Start(){
        // Grab the game objects with the tag "Core"
        planetCore = GameObject.FindGameObjectsWithTag("Core");
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Grab the playerGravity from GravityBehavior and move this object that vector
        // Initialize a Vector3 to the zero vector
        Vector3 gravitySum = Vector3.zero;
        for (int i = 0; i < planetCore.Length; i++){
            // Add the playerGravity of the planetCore to the gravitySum
            gravitySum += planetCore[i].GetComponent<GravityBehavior>().playerGravity;
        }
        characterController.Move(gravitySum);
    }
}
