using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangingRadiusCircularMovement : CircularMovement
{

    public float[] radiusMinMax;
    public float radiusChangeRate = 0.05f;
    private bool isGrowing = true;

    override protected void Update()
    {
        posX = centerOfRotation.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = centerOfRotation.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector3(posX, posY, transform.position.z);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360)
        {
            angle = 0;
        }

        if (rotationRadius >= radiusMinMax[1])
        {
            isGrowing = false;
        } else if (rotationRadius <= radiusMinMax[0])
        {
            isGrowing = true;
        }

        if (isGrowing)
        {
            rotationRadius += radiusChangeRate;
        }
        else
        {
            rotationRadius -= radiusChangeRate;
        }
    }
}
