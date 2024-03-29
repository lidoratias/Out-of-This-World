using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : LimitedMovement
{
    void Update()
    {
        moveCharacter(movement);
        /*if (movement.x != 0)
        {
            checkX();
        } else if (movement.y != 0)
        {
            checkY();
        }*/
    }

    override protected void moveCharacter(Vector2 direction)
    {
        if (direction.x != 0)
        {
            if (transform.position.x + (direction.x * speed * Time.deltaTime) < minXValue)
            {
                transform.position = new Vector3(
                    minXValue,
                    transform.position.y, transform.position.z);
                movement = new Vector2(movement.x * -1, movement.y);
            } else if (transform.position.x + (direction.x * speed * Time.deltaTime)
                > maxXValue)
            {
                transform.position = new Vector3(
                    maxXValue,
                    transform.position.y, transform.position.z);
                movement = new Vector2(movement.x * -1, movement.y);
            }
            else
            {
                transform.position = new Vector3(
                    transform.position.x + (direction.x * speed * Time.deltaTime),
                    transform.position.y, transform.position.z);
            }

        }
        
        if (direction.y != 0)
        {
            if (transform.position.y + (direction.y * speed * Time.deltaTime) < minYValue)
            {
                transform.position = new Vector3(transform.position.x,
                    minYValue,
                    transform.position.z);
                movement = new Vector2(movement.x, movement.y * -1);
            }
            else if (transform.position.y + (direction.y * speed * Time.deltaTime) 
                > maxYValue)
            {
                transform.position = new Vector3(transform.position.x,
                    maxYValue,
                    transform.position.z);
                movement = new Vector2(movement.x, movement.y * -1);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + (direction.y * speed * Time.deltaTime),
                    transform.position.z);
            }

        }
    }
}
