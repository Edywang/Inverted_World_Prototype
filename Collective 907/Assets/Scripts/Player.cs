using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float mouseSensitivity;
    CharacterController characterController;
    GameObject playerModel; 
    GameObject planetCore;
    private Camera currentCamera, cam1, cam2;
    private CameraBehavior[] cameras;
    private Vector3 upDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        planetCore = GameObject.FindGameObjectWithTag("Core");
        GameObject[] cameraArray = new GameObject[GameObject.FindGameObjectsWithTag("MainCamera").Length];
        cameraArray = GameObject.FindGameObjectsWithTag("MainCamera");
        // Set the playerModel to the object with the name Player Model
        playerModel = GameObject.Find("Player Model");
        cameras = new CameraBehavior[cameraArray.Length];
        for (int i = 0; i < cameraArray.Length; i++)
        {   
            cameras[i] = cameraArray[i].GetComponent<CameraBehavior>();
            //Debug.Log(cameras[i].name);
        }
        currentCamera = Camera.main;
        cam1.enabled = true;
        cam2.enabled = false;
        // Create a vector that is the character's orientation
    }

    // Update is called once per frame
    void Update()
    {
        upDirection = playerModel.transform.position - transform.position;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Rotate the character so transform.up is facing the planetCore.transform.position
        // Grab the object named Main Camera and rotate it by the mouse's x and y values
        Vector3 mouseMovement = new Vector3(-mouseY * mouseSensitivity, mouseX * mouseSensitivity, 0f);
        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].rotateHelper(mouseMovement, Space.Self);
        }
        playerModel.transform.LookAt(planetCore.transform.position);
        //Vector3 temp = (mouseMovement.normalized - upDirection.normalized) * mouseMovement.magnitude;
        playerModel.transform.LookAt(Vector3.ProjectOnPlane(upDirection.normalized, currentCamera.transform.forward.normalized));
        //playerModel.transform.Rotate(temp);
        //Debug.Log(temp);
        // Debug.Log("Current Camera forward: " + currentCamera.transform.forward);
        // Debug.Log("up Direction: " + upDirection);
        // Debug.Log("VECTOR3: " + Vector3.ProjectOnPlane(upDirection.normalized, currentCamera.transform.forward.normalized));
        // transform.Rotate(Quaternion.LookRotation(currentCamera.transform.forward, transform.forward));
        //Debug.DrawRay(transform.position, transform.forward);

        // WASD movement using characterController
        if (Input.GetKey(KeyCode.W)){
            characterController.Move(playerModel.transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            characterController.Move(playerModel.transform.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            characterController.Move(playerModel.transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            characterController.Move(playerModel.transform.right * -speed * Time.deltaTime);
        }
        // Add jumping based off of jumpForce
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded){
            characterController.Move(upDirection.normalized * jumpForce * Time.deltaTime);
        }
        //Debug.DrawRay(playerModel.transform.position, playerModel.transform.forward);
        //Debug.DrawRay(playerModel.transform.position, playerModel.transform.right);
        // Toggle camera POVs
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }

    }
}
