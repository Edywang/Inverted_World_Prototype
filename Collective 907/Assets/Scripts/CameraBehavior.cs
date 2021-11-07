using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    public Transform playerBody;
    public Transform playerModel;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation, -90f, 50f);
        // transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // //transform.Rotate(-mouseY, mouseX, 0);
        // playerBody.Rotate(Vector3.up * mouseX);
        // playerModel.Rotate(Vector3.up * mouseX);
    }
}
