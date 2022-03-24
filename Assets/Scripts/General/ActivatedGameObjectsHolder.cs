using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedGameObjectsHolder : MonoBehaviour
{

    public ActivatedGameObject[] objects;

    public ActivatedGameObject[] getObjectsArray()
    {
        return objects;
    }

    public void ActivateObject(int idx)
    {
        if (idx >= 0 && idx < objects.Length)
        {
            objects[idx].SetActive(true);
        }
    }

    public void DeactivateObject(int idx)
    {
        if (idx >= 0 && idx < objects.Length)
        {
            objects[idx].SetActive(false);
        }
    }

    public void ActivateAll()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }

    public void DeactivateAll()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }
}
