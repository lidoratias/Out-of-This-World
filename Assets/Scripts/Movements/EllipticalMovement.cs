using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticalMovement : MonoBehaviour
{
    public Transform centerOfRotation;

    public float rotationRadius = 2f, angularSpeed = 2f;

    private bool positiveDirection = true;
    public bool isHorizontal = false;

    float posX, posY;

    public float factor;

    public float angle;

    // Update is called once per frame
    void Update()
    {
        if (isHorizontal)
        {
            posX = centerOfRotation.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = centerOfRotation.position.y + Mathf.Sin(angle) * rotationRadius / factor;
        } else
        {
            posX = centerOfRotation.position.x + Mathf.Cos(angle) * rotationRadius / factor;
            posY = centerOfRotation.position.y + Mathf.Sin(angle) * rotationRadius;
        }

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

    public void setIsHorizontal(bool isHorizontal)
    {
        this.isHorizontal = isHorizontal;
    }

    public void setRadius(float radius)
    {
        this.rotationRadius = radius;
    }

    public void setSpeed(float speed)
    {
        this.angularSpeed = speed;
    }

    public void setMovingCenter(float speed)
    {
        this.centerOfRotation.GetComponent<LinearMovement>().enabled = true;
        LinearMovement lm = this.centerOfRotation.GetComponent<LinearMovement>();
        lm.setSpeed(speed);
    }
}
