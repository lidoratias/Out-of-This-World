using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{

    public Transform centerOfRotation;

    public float rotationRadius = 2f, angularSpeed = 2f;

    float posX, posY;

    public float angle;

    // Update is called once per frame
    void Update()
    {
        posX = centerOfRotation.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = centerOfRotation.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector3(posX, posY, transform.position.z);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360)
        {
            angle = 0;
        }

    }
}
