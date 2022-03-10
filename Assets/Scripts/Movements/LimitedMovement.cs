using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedMovement : BasicMovement
{
    [SerializeField]
    protected float minXValue;
    [SerializeField]
    protected float maxXValue;
    [SerializeField]
    protected float minYValue;
    [SerializeField]
    protected float maxYValue;

    protected virtual void checkX()
    {
        if (transform.position.x <= minXValue || transform.position.x >= maxXValue)
        {
            movement *= -1;
        }
    }

    protected virtual void checkY()
    {
        if (transform.position.y <= minYValue || transform.position.y >= maxYValue)
        {
            movement *= -1;
        }
    }

    public float getMinXValue()
    {
        return this.minXValue;
    }

    public float getMaxXValue()
    {
        return this.maxXValue;
    }

    public float getMinYValue()
    {
        return this.minYValue;
    }

    public float getMaxYValue()
    {
        return this.maxYValue;
    }

    public void setMinXValue(float min)
    {
        this.minXValue = min;
    }

    public void setMaxXValue(float max)
    {
        this.maxXValue = max;
    }

    public void setMinYValue(float min)
    {
        this.minYValue = min;
    }

    public void setMaxYValue(float max)
    {
        this.maxYValue = max;
    }
}
