using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Subject
{
    [Header("General Setup Settings")]
    private CharacterController CC;  
    public GameObject particle;
    bool dead; 

    private void Start()
    {
        CC = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 motion = move * Time.deltaTime * moveSpeed; 
        CC.Move(motion); 

        if (GetComponent<Rigidbody>().velocity.magnitude != 0 && !dead)
        {
            InstantiateParticle(particle);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            dead = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

}
