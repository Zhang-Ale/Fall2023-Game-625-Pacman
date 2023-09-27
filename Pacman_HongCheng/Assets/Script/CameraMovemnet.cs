using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemnet : Subject
{
    public Transform cameraTargetPos; 
    void Update()
    {
        if(menu.gameStarted)
        transform.position = Vector3.Lerp(transform.position, cameraTargetPos.position, Time.deltaTime * 2f);
    }
}
