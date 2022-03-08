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
}
