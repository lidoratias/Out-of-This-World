using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : Bullet
{
    protected override void Start()
    {
        //this.target = "Enemy";
        rb.velocity = this.direction * this.speed;
    }

}

/* THIS CLASS NEEDS TO BE CHANGED ASAP. IT SHOULD BE ABLE TO GET A DIRECTION AND THEN
 * MOVE IN THIS DIRECTION, NOT NECESSARILY RIGHT. ALSO, THE TARGET SETUP SHOULD BE EXTRACTED
 * TO A DIFFERENT CLASS, AND WE SHOULD HAVE EnemyBullet and PlayerBullet classes. */