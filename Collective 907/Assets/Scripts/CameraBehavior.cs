using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    GameObject player;
    public float rotateSpeed;
    public Vector3 offset;

    public float mouseSensitivity = 1f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(-mouseY, mouseX, 0);
        //playerBody.Rotate(Vector3.up * mouseX);
        
    }
    private void LateUpdate()
    {
        // offset based on mouse input
        // mouse x (horizontal)
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, Vector3.up) * offset;
        // mouse y (vertical, dependent on forward position)
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, Vector3.forward) * offset;
        // updates camera position based on player position
        //transform.position = player.transform.position + offset;
        // lookAt current player position
        //transform.LookAt(player.transform);
    }
}
