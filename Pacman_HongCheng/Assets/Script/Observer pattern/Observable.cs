using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void OnNotify(Action actionType);
}

public enum Action
{
    OnPlayerShoot,
    OnEnemyShot, 
    OnPowerUpCollect
}

public class Observable : MonoBehaviour
{
    //a collection of all the observers of this subject
    protected List<IObserver> _observers = new List<IObserver>();

    //add the observer to the list
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    //remove the observer from the list
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    //notify all observers
    public void Notify(Action actionType)
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnNotify(actionType);
        }
    }
}
