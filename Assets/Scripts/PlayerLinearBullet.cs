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
            GameObject explosionInstance = Instantiate(explosionEffect, transform.position, transform.rotation);
            explosionInstance.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f); 
        }

        if (hitInfo.tag == "Pirate Skull")
        {
            Destroyer.destroyObject(gameObject);
        }
    }
}
