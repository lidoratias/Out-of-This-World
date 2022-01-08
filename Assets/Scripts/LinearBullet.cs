using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : Bullet
{

    protected override void Start()
    {
        this.target = "Enemy";
        this.speed = 20.0f;
        this.direction = transform.right;
        rb.velocity = this.direction * this.speed;
    }
    

}
