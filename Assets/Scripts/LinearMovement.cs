using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{

    public float speed = 3.0f;
    public float minValue;
    public float maxValue;
    public Rigidbody2D rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(0.0f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 pos = Camera.main.WorldToViewportPoint(rb.position);
        
        if (pos.y < minValue)
        {
            movement.Set(0.0f, 1.0f);
        }
        
        if (pos.y > maxValue)
        {
            movement.Set(0.0f, -1.0f);
        }
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.velocity = this.speed * direction;
    }
}
