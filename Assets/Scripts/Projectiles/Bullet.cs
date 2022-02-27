using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed = 3.0f;
    public int damage = 20;
    public Rigidbody2D rb;
    protected Vector2 direction;
    protected string target;

    protected virtual void Start(){}

    public int getDamage()
    {
        return this.damage;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public float getSpeed()
    {
        return this.speed;
    }

    public Vector2 getDirection()
    {
        return this.direction;
    }

    public void setVelocity(Vector2 velocity)
    {
        this.rb.velocity = velocity;
    }

    public Vector2 getVelocity()
    {
        return this.rb.velocity;
    }

}
