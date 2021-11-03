using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
     private int currentCameraIndex;
     public Camera[] Cameras;
     // Use this for initialization
     void Start () {
        currentCameraIndex = 0;
        /*
        cameras = new Camera[GameObject.FindObjectsOfType(typeof(Camera)).Length];
        cameras = (Camera[]) GameObject.FindObjectsOfType(typeof(Camera));
        */
         for (int i = 1; i < Cameras.Length; i++){
            Cameras[i].gameObject.SetActive(false);
         }
         Cameras[0].gameObject.SetActive(true);
         
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            Cameras[currentCameraIndex].enabled = false;
            if (++currentCameraIndex > Cameras.Length - 1) currentCameraIndex = 0;
            Cameras[currentCameraIndex].enabled = true;
            Debug.Log ("Camera with name: " + Cameras[currentCameraIndex].name + ", is now enabled");
        }
    }
}
