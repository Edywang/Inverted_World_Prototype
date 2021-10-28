using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrb : MonoBehaviour
{
    public float Gravity;
    public bool FixedDirection;

    private void OnTriggerEnter(Collider other)
    {
        // If the object should have gravity act on it
        if(other.GetComponent<GravityController>()){
            // Change the gravity to this object
            other.GetComponent<GravityController>().Gravity = this.GetComponent<GravityOrb>();
        }
    }
}
