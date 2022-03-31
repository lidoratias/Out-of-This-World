using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearOperatableObject : OperatableObject
{
    public LinearMovement lm;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        lm.setMinXValue(-1000);
        lm.setMaxXValue(1000);
        lm.setMinYValue(-1000);
        lm.setMaxYValue(1000);
        lm.setSpeed(speed);
        lm.enabled = false;
    }

    protected virtual void Activate()
    {
        lm.enabled = true;
    }

    protected void Disactivate()
    {
        lm.enabled = false;
    }

    public override void Operate()
    {
        lm.enabled = true;
    }
}
