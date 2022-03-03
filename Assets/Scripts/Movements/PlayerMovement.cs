using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15.0f;
    public Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        Vector2 directionWithinWorld = direction;
        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y < 0.1 && direction.y < 0)
        {
            directionWithinWorld.y = 0;
        } else if (pos.y > 1 && direction.y > 0)
        {
            directionWithinWorld.y = 0;
        }

        if (pos.x < 0 && direction.x < 0)
        {
            directionWithinWorld.x = 0;
        }
        else if (pos.x > 0.9 && direction.x > 0)
        {
            directionWithinWorld.x = 0;
        }
        transform.Translate(directionWithinWorld * this.speed * Time.deltaTime);
    }
}
