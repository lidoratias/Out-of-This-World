using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDirectedBullet : DirectedBullet
{
    public GameObject explosionEffect;
    public Vector3 explosionSize;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (this.targets.Contains(hitInfo.tag)) //Player
        {
            GameObject explosionInstance = Instantiate(explosionEffect, transform.position,
                new Quaternion(0, 0, 0, 1));
            explosionInstance.transform.localScale = explosionSize;
            Destroy(gameObject);
        }
    }
}