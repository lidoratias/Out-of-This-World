using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalMovement : MonoBehaviour
{
    public Transform centerOfRotation;

    public float rotationRadius = 2f, angularSpeed = 2f;

    private bool positiveDirection = true;

    float posX, posY;

    public float angle;

    // Update is called once per frame
    void Update()
    {
        posX = centerOfRotation.position.x + Mathf.Cos(angle) * rotationRadius / 2;
        posY = centerOfRotation.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        if (positiveDirection)
        {
            angle = angle + Time.deltaTime * angularSpeed;
        }
        else
        {
            angle = angle - Time.deltaTime * angularSpeed;
        }

        if (angle >= 360)
        {
            angle = 0;
        }

    }

    public void turnDirection()
    {
        if (positiveDirection) {
            positiveDirection = false;
        } else {
            positiveDirection = true;
        }
    }
}
