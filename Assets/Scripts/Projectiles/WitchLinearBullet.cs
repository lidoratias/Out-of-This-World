using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchLinearBullet : LinearBullet
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (this.targets.Contains(hitInfo.tag)) //Player
        {
            /*GameObject explosionInstance = Instantiate(explosionEffect, transform.position,
                new Quaternion(0, 0, 0, 1));
            explosionInstance.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);*/
            Destroy(gameObject);
        }
    }
}
