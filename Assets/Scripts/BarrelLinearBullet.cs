using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelLinearBullet : LinearBullet
{
    public GameObject explosionEffect;

    protected override void Start()
    {
        this.target = "Player";
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            GameObject explosionInstance = Instantiate(explosionEffect, transform.position,
                new Quaternion(0, 0, 0, 1));
            explosionInstance.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
        }
    }
}
