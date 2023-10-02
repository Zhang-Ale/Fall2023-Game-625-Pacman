using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfInterest : NewSubject
{
    [SerializeField] private string poiName;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Notify(poiName, NotificationType.AchievementUnlocked);
            Destroy(this.gameObject); 
        }
    }
}
