using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEffect : Effect
{
    // Start is called before the first frame update
    void Awake()
    {
        this.enabled = false;
    }

    void OnEnable()
    {
        LinearMovement lm = gameObject.GetComponent<LinearMovement>();
        lm.setSpeed(lm.getSpeed() * 4.0f);
    }
}
