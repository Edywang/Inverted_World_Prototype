using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // public float mouseSensitivity = 1f;
    // float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //     float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    //     transform.Rotate(-mouseY, mouseX, 0f);
    // }
    public void rotateHelper(Vector3 eulers, Space relativeTo = Space.Self)
    {
        transform.Rotate(eulers, relativeTo);
    }
}
