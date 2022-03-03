using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : LimitedMovement
{
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

    override protected void moveCharacter(Vector2 direction)
    {
        if (direction.x != 0)
        {
            transform.position = new Vector3(
                transform.position.x + (direction.x * speed * Time.deltaTime),
                transform.position.y, transform.position.z);
        } else if (direction.y != 0)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y + (direction.y * speed * Time.deltaTime),
                transform.position.z);
        }
    }
}
