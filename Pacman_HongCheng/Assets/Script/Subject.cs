using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public int moveSpeed = 30;
    protected Color color;
    protected void InstantiateParticle(GameObject part) 
    {
        Instantiate(part, transform.position, Quaternion.identity); 
    } 
}
