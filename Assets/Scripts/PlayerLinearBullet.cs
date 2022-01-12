using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLinearBullet : LinearBullet
{

    public GameObject explosionEffect;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        if (hitInfo.tag == "Pirate Skull")
        {
            Destroyer.destroyObject(gameObject);
        }
    }
}
