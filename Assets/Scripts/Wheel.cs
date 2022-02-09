using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{

    private bool rotateRight = true;

    // Update is called once per frame
    void Update()
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

    void rotateWheelRight()
    {
        transform.Rotate(0, 0, -0.2f, Space.Self);
    }

    void rotateWheelLeft()
    {
        transform.Rotate(0, 0, 0.2f, Space.Self);
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
