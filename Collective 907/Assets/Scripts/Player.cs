using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 lastDirection;
    public Vector3 currentEulerAngles;
    Quaternion currentRotation;
    public float speed;
    public float rotationSpeed;
    CharacterController characterController;
    GameObject planetCore;
    public Camera currentCamera, cam1, cam2;
    private Vector3 moveDirection;
    public Vector3 upDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        planetCore = GameObject.FindGameObjectWithTag("Core");
        lastDirection = transform.position - planetCore.transform.position;
        currentCamera = Camera.main;
        cam1.enabled = true;
        cam2.enabled = false;
        // Create a vector that is the character's orientation
        moveDirection = transform.TransformDirection(Vector3.forward);
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
        // Basic character movement based off character controller and moveDirection

        if (characterController.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;
            //characterController.SimpleMove(moveDirection);
        }

        // // Set the up direction to the normalized vector from the player to the core
        upDirection = transform.position - planetCore.transform.position;
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

    private void OnCollision(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            Destroy(other.gameObject);
        }
    }


    // void LateUpdate()
    // {
    //     // Determine the player's position from the core
    //     //Vector3.Angle(lastDirection, upDirection)
    //     // transform.Rotate(upDirection);
    //     // lastDirection = upDirection;
    //     // Quaternion targetRotation = Quaternion.LookRotation (planetCore.transform.position - transform.position);
    //     // float str = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
    //     // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    // }
}
