using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpawner : MonoBehaviour
{
    public GameObject puPrefab;
    public AchievementSystem AS;
    public void Spawn()
    {
        Instantiate(puPrefab, transform.position, Quaternion.identity);
        AS.Register();
        Debug.Log("A new power up has been spawned.");
    }
}
