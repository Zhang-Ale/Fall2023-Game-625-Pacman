using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewObserver : MonoBehaviour
{
    public abstract void OnNotify(object value, NotificationType noType); 
}

public class NewSubject : MonoBehaviour 
{
    private List<NewObserver> _observers = new List<NewObserver>(); 

    public void RegisterObserver(NewObserver observer)
    {
        _observers.Add(observer); 
    }

    public void Notify(object value, NotificationType noType)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(value, noType); 
        }
    }
}

public enum NotificationType
{
    AchievementUnlocked
}

