using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject
{
    public void register(Observer ob);
    public void unregister(Observer ob);
    public void notifyObservers();
}
