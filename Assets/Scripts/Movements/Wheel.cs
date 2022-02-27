using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{

    private bool rotateRight = true;
    public float pace;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateRight)
        {
            rotateWheelRight();
        }
        else
        {
            rotateWheelLeft();
        }
    }

    public void setPace(float pace)
    {
        this.pace = pace;
    }

    void rotateWheelRight()
    {
        transform.Rotate(0, 0, -pace, Space.Self);
    }

    void rotateWheelLeft()
    {
        transform.Rotate(0, 0, pace, Space.Self);
    }

    public void setRotateRight(bool rotateRight)
    {
        this.rotateRight = rotateRight;
    }

    public bool getRotateRight()
    {
        return this.rotateRight;
    }
}
