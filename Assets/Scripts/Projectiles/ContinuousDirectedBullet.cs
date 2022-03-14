using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDirectedBullet : Bullet
{
    public float step;

    // Update is called once per frame
    override protected void Update()
    {
        GameObject targetGameObject = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(transform.position,
            targetGameObject.transform.position, step);
    }
}
