using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : HittingEnemy
{
    public float speed = 3.0f;
    public Rigidbody2D rb;
    public Vector2 direction;
    protected ArrayList targets = new ArrayList();

    override protected void Start(){}

    override protected void Update()
    {
        if (Mathf.Abs(transform.position.x) > 12 || Mathf.Abs(transform.position.y) > 6)
        {
            Destroy(gameObject);
        }
    }

    public ArrayList getTargets()
    {
        return targets;
    }

    public void setTargets(string[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            this.targets.Add(targets[i]);
        }
    }

    /*public int getDamage()
    {
        return this.damage;
    }*/

    public void setSpeed(float speed)
    {
        this.speed = speed;
        rb.velocity = this.direction * this.speed;
    }

    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = this.direction * this.speed;
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

    public void AddForce(Vector3 force)
    {
        this.rb.AddForce(force);
    }
}
