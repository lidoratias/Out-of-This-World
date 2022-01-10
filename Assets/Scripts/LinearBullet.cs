using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : Bullet
{
    public GameObject explosionEffect;

    protected override void Start()
    {
        this.target = "Enemy";
        this.speed = 50.0f;
        this.direction = transform.right;
        rb.velocity = this.direction * this.speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            Instantiate(this.explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
