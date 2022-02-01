using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    public Rigidbody2D rb;
    public float rotateSpeed = 2.0f;
    float latestY;
    public GameObject explosionEffect;
    public Sprite[] sprites;
    private int mode = 1;

    // Start is called before the first frame update
    void Start()
    {
        latestY = transform.position.y;
        rb.AddForce(new Vector3(0, Random.Range(550, 600), 0));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, rotateSpeed);
        if (latestY > transform.position.y)
        {
            Explode();
        }
        latestY = transform.position.y;
    }

    void Explode() {
        //TODO BOOM ANIMATION AND INSTANTIATION OF 4 BULLETS
        GameObject explosionInstance = Instantiate(explosionEffect, transform.position,
            new Quaternion(0, 0, 0, 1));
        explosionInstance.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
        Destroy(gameObject);
    }
}
