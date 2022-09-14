using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : HittingEnemy
{

    public Rigidbody2D rb;
    public Sprite[] sprites;
    private float horizontalSpeed;
    private float startPos;

    public GameObject explosionEffect;
    public Vector3 explosionSize;
    protected ArrayList targets = new ArrayList();

    private const float MIN_SPEED = 0.002f;
    private const float MAX_SPEED = 0.013f;
    private const int MIN_FORCE = 450;
    private const int MAX_FORCE = 650;
    private const int MIN_X = -8;
    private const int MAX_X = 8;

    override protected void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 5)];
        generateStartPos();
        initSpeedAndForce();
        targets.Add("Player");
    }

    public void initSpeedAndForce()
    {
        if (startPos <= 0.5f)
        {
            horizontalSpeed = MIN_SPEED + ((1 - startPos) * (MAX_SPEED - MIN_SPEED));
        }
        else
        {
            horizontalSpeed = (-1) * (MIN_SPEED + (startPos * (MAX_SPEED - MIN_SPEED)));
        }
        rb.AddForce(new Vector3(0, Random.Range(MIN_FORCE, MAX_FORCE), 0));
    }

    public void generateStartPos()
    {
        startPos = Random.Range(0.0f, 1.0f);
        transform.position = new Vector3(MIN_X + (MAX_X - MIN_X) * startPos,
            transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    override protected void Update()
    {
        transform.position = new Vector3(transform.position.x + horizontalSpeed, transform.position.y, transform.position.z);
        if (transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }
    }

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
