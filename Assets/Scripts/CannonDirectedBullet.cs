using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDirectedBullet : DirectedBullet
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player Bullet")
        {
            Destroy(gameObject);
        }
    }
}
