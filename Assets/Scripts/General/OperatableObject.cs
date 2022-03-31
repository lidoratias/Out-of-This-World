using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatableObject : MonoBehaviour, Subject
{
    private List<Observer> observers = new List<Observer>();

    public virtual void Operate() { }

    public void register(Observer ob)
    {
        observers.Add(ob);
    }

    public void unregister(Observer ob)
    {
        observers.Remove(ob);
    }

    public void notifyObservers()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].updateRecieved();
        }
    }
}
