using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedBullet : Bullet
{
    protected override void Start()
    {
        //this.speed = 1.0f;
        GameObject targetGameObject = GameObject.Find("Player");
        this.direction = targetGameObject.transform.position - transform.position;
        rb.velocity = this.direction * this.speed;
    }

}
