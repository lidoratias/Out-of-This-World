using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedGameObject : MonoBehaviour
{
    public void SetActive(bool setActive)
    {
        gameObject.SetActive(setActive);
    }

    public void phaseOut() { }
    public void phaseIn() { }
}
