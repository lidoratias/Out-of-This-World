using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        RotateTowards.rotateTowards(transform, target.transform, speed);
    }
}
