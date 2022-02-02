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
        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
        
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

    protected void moveCharacter(Vector2 direction)
    {
        transform.Translate(direction * this.speed * Time.deltaTime);
    }
}
