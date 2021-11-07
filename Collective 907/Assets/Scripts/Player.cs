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
        upDirection = transform.position - planetCore.transform.position;
        
        // Raycast down to find the ground

        // RaycastHit hit;
        // Physics.Raycast(transform.position, -upDirection, out hit, 100);
        // Debug.DrawRay(transform.position, upDirection);

        transform.LookAt(upDirection);

        // WASD movement using characterController
        if (Input.GetKey(KeyCode.W)){
            characterController.Move(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            characterController.Move(transform.up * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            characterController.Move(transform.right * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            characterController.Move(transform.right * speed * Time.deltaTime);
        }
        // Add jumping based off of jumpForce
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded){
            characterController.Move(upDirection.normalized * jumpForce * Time.deltaTime);
        }
        // Toggle camera POVs
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}
