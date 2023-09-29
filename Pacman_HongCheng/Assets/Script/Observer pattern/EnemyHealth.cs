using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Observable
{
    int health = 3;
    public int currentHealth;
    CameraScript CS; 
    void Start()
    {
        currentHealth = health;
        CS = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

    public void IsDestroyed()
    {
        if(currentHealth == 0)
        {
            CS.ShakeCam(0.1f, 0.5f);
            CS.ResetShake();
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Notify(Action.OnEnemyShot);
            currentHealth -= 1; 
        }
    }

    private void Awake()
    {
        IObserver gm = GameObject.FindFirstObjectByType<PlayerActions>();
        AddObserver(gm);
    }

    private void OnDisable()
    {
        IObserver gm = GameObject.FindFirstObjectByType<PlayerActions>();
        RemoveObserver(gm);
    }
}
