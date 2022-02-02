using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLinearBullet : LinearBullet
{

    public GameObject explosionEffect;
    public string[] ignoreTags;
    public string[] destroyerTags;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        for (int i = 0; i < ignoreTags.Length; i++)
        {
            if (ignoreTags[i] == hitInfo.tag)
            {
                return;
            }
        }

        GameObject explosionInstance = Instantiate(explosionEffect, transform.position, transform.rotation);
        explosionInstance.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        for (int i = 0; i < destroyerTags.Length; i++)
        {
            if(destroyerTags[i] == hitInfo.tag)
            {
                Destroyer.destroyObject(gameObject);
            }
        }
    }
}
