using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{

    public float speed = 3.0f;
    public float minValue;
    public float maxValue;
    public Vector2 movement;
    private Vector2 pos;

    // Start is called before the first frame update
    protected void Start()
    {}


    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (movement.x != 0)
        {
            checkX();
        } else if (movement.y != 0)
        {
            checkY();
        }
        moveCharacter(movement);
    }

    protected void moveCharacter(Vector2 direction)
    {
        transform.Translate(direction * this.speed * Time.deltaTime);
    }

    void checkX()
    {
        if (pos.x <= minValue || pos.x >= maxValue)
        {
            movement *= -1;
        }
    }

    void checkY()
    {
        if (pos.y <= minValue || pos.y >= maxValue)
        {
            movement *= -1;
        }
    }
}
