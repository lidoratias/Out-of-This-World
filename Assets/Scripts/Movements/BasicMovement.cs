using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    protected float speed = 3.0f;
    [SerializeField]
    protected Vector2 movement;

    virtual protected void moveCharacter(Vector2 direction) { }
}
