using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // public float mouseSensitivity = 1f;
    public float damage;
    // float xRotation = 0f;
    public LaserScript laserScript;
    // Start is called before the first frame update
    public ParticleSystem part;
    public GameObject planetCore;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Clicked Primary Mouse Button");
            ShootLaser(transform.position, transform.forward);
        }
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // transform.Rotate(-mouseY, mouseX, 0f);
    }

    void ShootLaser(Vector3 startPosition, Vector3 direction){
        part.Play();
        Ray ray = new Ray(startPosition, direction);
        //LineRenderer.DrawRay(transform.position, ray);
        //Debug.Log("ray: " + ray);
        if(Physics.Raycast(ray, out RaycastHit hit)){
            laserScript.SetLaserPositions(planetCore.transform.position, hit);
            EnemyScript target = hit.collider.transform.gameObject.GetComponent<EnemyScript>();
            //Debug.Log("HIT: " + hit.collider.transform.gameObject.name);
            if (target != null) {
                target.takeHit(damage);
                Debug.Log("HIT: " + damage);
            }
        }
    }
    public void rotateHelper(Vector3 eulers, Space relativeTo = Space.Self)
    {
        transform.Rotate(eulers, relativeTo);
    }
}
