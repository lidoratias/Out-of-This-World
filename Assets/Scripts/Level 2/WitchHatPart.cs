using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHatPart : MonoBehaviour
{
    public void flicker()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
    }

    public void unflicker()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1.0f);
    }
}
