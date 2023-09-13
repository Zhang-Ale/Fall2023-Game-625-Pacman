using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpawner : MonoBehaviour
{
    public GameObject puPrefab;

    public void Spawn()
    {
        Instantiate(puPrefab, transform.position, Quaternion.identity);
    }
}
