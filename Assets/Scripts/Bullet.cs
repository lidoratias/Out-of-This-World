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

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    public int getDamage()
    {
        return this.damage;
    }

}
