using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject parentGhost;
    public Vector3 explosionSize;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            Vector3 explosionPosition = new Vector3(transform.position.x, transform.position.y + 1.0f,
                transform.position.z);
            GameObject explosionInstance = Instantiate(explosionEffect, explosionPosition,
                new Quaternion(0, 0, 0, 1));
            explosionInstance.transform.localScale = explosionSize;
            if (timer >= 0.5)
            {
                Destroy(parentGhost);
            }
        }
    }
}