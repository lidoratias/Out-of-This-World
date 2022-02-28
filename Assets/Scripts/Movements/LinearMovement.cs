using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{

    public float speed = 3.0f;
    public float minValue;
    public float maxValue;
    public Vector2 movement;

    // Start is called before the first frame update
    protected void Start()
    {}


    void Update()
    {
        moveCharacter(movement);
        if (movement.x != 0)
        {
            checkX();
        } else if (movement.y != 0)
        {
            checkY();
        }
    }

    protected void moveCharacter(Vector2 direction)
    {
        if (direction.x != 0)
        {
            transform.position = new Vector2(
                transform.position.x + (direction.x * speed * Time.deltaTime),
                transform.position.y);
        } else if (direction.y != 0)
        {
            transform.position = new Vector2(transform.position.x,
                transform.position.y + (direction.y * speed * Time.deltaTime));
        }
    }

    void checkX()
    {
        if (transform.position.x <= minValue || transform.position.x >= maxValue)
        {
            movement *= -1;
        }
    }

    void checkY()
    {
        if (transform.position.y <= minValue || transform.position.y >= maxValue)
        {
            movement *= -1;
        }
    }
}
