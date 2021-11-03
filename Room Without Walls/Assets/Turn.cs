using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private Camera cam;
    public float sens = .5f;
    public Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sens;
        turn.y += Input.GetAxis("Mouse Y") * sens;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    public float Width
    {
        get
        {
            Vector3 screenWidth = new Vector3(Screen.width, 0);
            return cam.ScreenToWorldPoint(screenWidth).x * 2;
        }
    }

    public float Height
    {
        get
        {
            Vector3 screenHeight = new Vector3(Screen.height, 0);
            return cam.ScreenToWorldPoint(screenHeight).y * 2;
        }
    }
}
