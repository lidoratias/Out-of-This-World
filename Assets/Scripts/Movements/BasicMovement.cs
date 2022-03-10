using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    protected float speed = 3.0f;
    [SerializeField]
    protected Vector2 movement;

    virtual protected void moveCharacter(Vector2 direction) { }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public float getSpeed()
    {
        return this.speed;
    }

    public void setMovement(Vector2 movement)
    {
        this.movement = movement;
    }

    public Vector2 getMovement()
    {
        return this.movement;
    }
}
