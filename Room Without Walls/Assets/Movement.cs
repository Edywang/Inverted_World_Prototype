using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        gameObject.transform.position = new Vector3(transform.position.x + (h * speed), transform.position.y, transform.position.z + (v * speed));
        if (transform.position.x > 15 || transform.position.x < -15){
            gameObject.transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 15 || transform.position.z < -15){
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        }

    }
}
