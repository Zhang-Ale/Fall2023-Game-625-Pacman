using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Observable
{
    int health = 3;
    public int currentHealth;
    Menu menu;
    AudioSource AS;
    public Material whiteMat;
    MeshRenderer rend;
    Material ogMat; 
    void Start()
    {
        currentHealth = health;
        rend = GetComponent<MeshRenderer>();
        AS = GetComponent<AudioSource>();
        menu = GameObject.Find("Canvas").GetComponent<Menu>();
        ogMat = rend.material;
    }

    public void Update()
    {
        if(currentHealth == 0)
        {
            menu.AddPoint();
            Notify(Action.OnEnemyDestroy);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            StartCoroutine("TakeDamage");
            currentHealth -= 1;
        }
    }

    IEnumerator TakeDamage()
    {
        AS.Play();
        rend.material = whiteMat;
        yield return new WaitForSeconds(0.1f);
        rend.material = ogMat; 
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
