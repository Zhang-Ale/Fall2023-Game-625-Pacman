using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class AchievementSystem : NewObserver
{
    public TextMeshProUGUI achieveText;
    [SerializeField] int number; 
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Register();
    }
    private void Update()
    {
        achieveText.text = "" + number;
    }

    public void Register()
    {
        foreach (var poi in FindObjectsOfType<PointsOfInterest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(object value, NotificationType noType)
    {
        if(noType == NotificationType.AchievementUnlocked)
        {
            string achievementKey = "achievement-" + value; 
            if(PlayerPrefs.GetInt(achievementKey) == 1)
                return;
            PlayerPrefs.SetInt(achievementKey, 1);
            number++;
            Debug.Log("Unlocked" + value);
            
        }
    }
}
