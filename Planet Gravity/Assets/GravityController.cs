using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    public GravityOrb Gravity;
    private Rigidbody Rb;
    public float RotationSpeed = 20;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Gravity){
            Vector3 gravityUp = Vector3.zero;
            if(Gravity.FixedDirection){
                gravityUp = Gravity.transform.up;
            }
            else{
                gravityUp = (transform.position - Gravity.transform.position).normalized;
            }
            gravityUp = (transform.position - Gravity.transform.position).normalized;
            Vector3 localUp = transform.up;
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);
            // Push down on the object according to gravity
            Rb.AddForce((-gravityUp * Gravity.Gravity) * Rb.mass);
        }
    }
}