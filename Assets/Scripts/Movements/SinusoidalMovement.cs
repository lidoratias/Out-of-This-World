using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : BasicMovement
{
    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        moveCharacter(movement);
    }

    override protected void moveCharacter(Vector2 direction)
    {
        if (direction.x != 0)
        {
            if (direction.x > 0)
                pos += transform.right * Time.deltaTime * speed;
            else
                pos -= transform.right * Time.deltaTime * speed;
            transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        }
        else if (direction.y != 0)
        {
            if (direction.y > 0)
                pos += transform.up * Time.deltaTime * speed;
            else
                pos -= transform.up * Time.deltaTime * speed;
            transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }
}
