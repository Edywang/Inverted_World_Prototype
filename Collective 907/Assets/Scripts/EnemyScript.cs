using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public float aggroRadius;
    Vector3 startPosition;
    Animator anim;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Enemy") {
            anim.SetBool("isAttacking", true);
        }
        Vector3 vectortoTarget = player.transform.position - transform.position;
        float distanceToTarget = vectortoTarget.magnitude;
        if(distanceToTarget <= aggroRadius) {
            agent.SetDestination(player.transform.position);
        }
        else {
            agent.SetDestination(startPosition);
        }
    }
    
    public void takeHit(float damage){
        health -= damage;
        if(health <= 0.0f) {
            Destroy(this.gameObject);
        }
    }
}