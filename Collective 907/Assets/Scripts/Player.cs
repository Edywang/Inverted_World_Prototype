using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    CharacterController characterController;
    GameObject planetCore;
    private Camera currentCamera, cam1, cam2;
    private Vector3 upDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        planetCore = GameObject.FindGameObjectWithTag("Core");
        currentCamera = Camera.main;
        cam1.enabled = true;
        cam2.enabled = false;
        // Create a vector that is the character's orientation
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // Vector3 relativeToCore = transform.position - planetCore.transform.position;

        // Character movement
        // Vector3 movement = 
        //     currentCameara.transform.right * Input.GetAxis("Horizontal") 
        //     + currentCameara.transform.forward * Input.GetAxis("Vertical");
        // movement = Vector3.ClampMagnitude(movement, 1);
        // movement *= speed * Time.deltaTime;
        // characterController.SimpleMove(movement);
        
        upDirection = transform.position - planetCore.transform.position;

        // Raycast down to find the ground
        RaycastHit hit;
        Physics.Raycast(transform.position, -upDirection, out hit, 100);
        Debug.DrawRay(transform.position, upDirection);

        // WASD movement using characterController
        if (Input.GetKey(KeyCode.W)){
            characterController.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            characterController.Move(transform.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            characterController.Move(transform.right * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            characterController.Move(transform.right * speed * Time.deltaTime);
        }
        // Add jumping based off of jumpForce
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded){
            characterController.Move(transform.up * jumpForce * Time.deltaTime);
        }

        // // Set the up direction to the normalized vector from the player to the core
        
        // //transform.rotation = Vector3.Lerp(transform.position, planetCore.transform.position, rotationSpeed);
        // currentEulerAngles = upDirection * Time.deltaTime * rotationSpeed;
        // currentRotation.eulerAngles = currentEulerAngles;
        // transform.rotation = currentRotation;

        // Rotate
        // Vector3 cameraDirection = currentCameara.transform.forward;
        // cameraDirection.y = 0;
        // transform.LookAt(transform.position + cameraDirection);

        // Toggle camera POVs
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}
