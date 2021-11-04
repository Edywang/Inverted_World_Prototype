using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    CharacterController characterController;
    GameObject planetCore;
    public Camera currentCameara, cam1, cam2;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        planetCore = GameObject.FindGameObjectWithTag("Core");
        currentCameara = Camera.main;
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativeToCore = (transform.position - planetCore.transform.position);
        // character movement
        Vector3 movement = 
            currentCameara.transform.right * Input.GetAxis("Horizontal") 
            + currentCameara.transform.forward * Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1);
        movement *= speed * Time.deltaTime;
        characterController.SimpleMove(movement);

        // rotate
        Vector3 cameraDirection = currentCameara.transform.forward;
        cameraDirection.y = 0;
        transform.LookAt(transform.position + cameraDirection);

        // toggle camera POVs
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }

    void LateUpdate() 
    {
        // determine the player's position from the core
        Quaternion targetRotation = Quaternion.LookRotation (planetCore.transform.position - transform.position);
        float str = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    }
}
