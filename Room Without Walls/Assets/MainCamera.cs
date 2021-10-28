using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
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
