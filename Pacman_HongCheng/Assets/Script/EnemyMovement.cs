using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyMovement : Subject
{
    public GameObject player;
    NavMeshAgent enemy;
    public GameObject part; 

    void Start()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        enemy.SetDestination(player.transform.position); 
        if(enemy.GetComponent<Rigidbody>().velocity.magnitude != 0)
        {
            Invoke("Insta", 5);  
        }
    }

    void Insta()
    {
        InstantiateParticle(part);
    }
}
