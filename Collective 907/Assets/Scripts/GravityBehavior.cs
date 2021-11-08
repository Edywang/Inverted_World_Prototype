using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Source for code:
* https://gamedev.stackexchange.com/questions/63545/how-to-change-gravity-towards-certain-object-in-unity
*/
public class GravityBehavior : MonoBehaviour
{
    public Vector3 playerGravity;
    private Vector3 playerDistance;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // We can add more moving objects here to assign relative weight
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        // Log the core's position
        Debug.Log("Core's position: " + transform.position);
        // Log the player's position
        Debug.Log("Player's position: " + player.transform.position);
        // get playerDistance
        playerDistance = player.transform.position - transform.position;
        // Log the offset
        Debug.Log("Player's distance from core to player: " + playerDistance);
        // Assign playerGravity as a Vector3 with offset's values absolute valued & square rooted
        playerGravity = new Vector3(Mathf.Sqrt(Mathf.Abs(playerDistance.x)), Mathf.Sqrt(Mathf.Abs(playerDistance.y)), Mathf.Sqrt(Mathf.Abs(playerDistance.z)));
        // Restore playerGravity's sign
        if (playerDistance[0] < 0.0f)
        {
            playerGravity[0] = -playerGravity[0];
        }
        if (playerDistance[1] < 0.0f)
        {
            playerGravity[1] = -playerGravity[1];
        }
        if (playerDistance[2] < 0.0f)
        {
            playerGravity[2] = -playerGravity[2];
        }
        // Log "playerGravity adjusted" and the playerGravity
        Debug.Log("playerGravity adjusted: " + playerGravity);
    }
}
