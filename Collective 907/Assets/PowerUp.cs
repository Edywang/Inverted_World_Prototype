using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other) 
    {

        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        //Spawn cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //Apply the effect


        Destroy(gameObject);
    }
}
