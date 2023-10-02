using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Observable
{
    int health = 3;
    public int currentHealth;
    CameraScript CS;
    Menu menu; 
    void Start()
    {
        currentHealth = health;
        CS = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        menu = GameObject.Find("Canvas").GetComponent<Menu>();
    }

    public void Update()
    {
        if(currentHealth == 0)
        {
            menu.AddPoint();
            Notify(Action.OnEnemyDestroy);
            CS.ShakeCam(0.1f, 0.5f);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
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
