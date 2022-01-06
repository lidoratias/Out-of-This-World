using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 15.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movement.x > 0)
            animator.SetInteger("Speed", 1);
        else if (movement.x < 0)
            animator.SetInteger("Speed", -1);
        else
            animator.SetInteger("Speed", 0);
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.velocity = this.speed * direction;
    }
}
