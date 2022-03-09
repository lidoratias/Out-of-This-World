using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringObject : MonoBehaviour
{
    private bool isOn;

    public void setIsOn(bool isOn)
    {
        this.isOn = isOn;
    }

    public bool getIsOn()
    {
        return this.isOn;
    }

    public void flicker()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
    }

    public void unflicker()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1.0f);
    }
}
