using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Subject
{
    [Header("General Setup Settings")]
    private CharacterController CC;
    Rigidbody RB; 
    public GameObject particle, PUparticle; 
    bool dead;
    public Spawner spawner;

    private void Start()
    {
        poweredUp = false; 
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        pus = GameObject.FindGameObjectWithTag("PUS").GetComponent<PUSpawner>();
        CC = GetComponent<CharacterController>();
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (menu.gameStarted)
        {
            spawner.enabled = true;
            RB.constraints = RigidbodyConstraints.None;
            RB.constraints = RigidbodyConstraints.FreezePositionY;
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 motion = move * Time.deltaTime * moveSpeed;
            CC.Move(motion);
        }

        if (GetComponent<Rigidbody>().velocity.magnitude != 0 && !dead)
        {
            InstantiateParticle(particle);
        }

        if (poweredUp)
        {
           StartCoroutine(PowerUpTime()); 
        }
        else
        {
            StopCoroutine(PowerUpTime());
        }
    }

    IEnumerator PowerUpTime()
    {
        InstantiateParticle(PUparticle);
        yield return new WaitForSeconds(powerUpDuration);
        poweredUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (!poweredUp)
            {
                dead = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                menu.gameStarted = false;
                spawner.enabled = false;
                menu.StopGame(); 
            }
            else
            {
                dead = false;
                Destroy(other.gameObject);
                menu.AddPoint(); 
            }
        }

        if(other.tag == "PowerUp")
        {
            poweredUp = true;
            Destroy(other.gameObject);
            pus.Spawn(); 
        }
    }
}
