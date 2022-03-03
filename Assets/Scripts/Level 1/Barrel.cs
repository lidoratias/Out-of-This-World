using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : HittingEnemy
{
    public Rigidbody2D rb;
    public GameObject explosionEffect;
    public Sprite[] sprites;
    public Bullet bullet;

    private int mode = 1;

    private float latestY;
    public float rotateSpeed = 2.0f;
    public float speed = 4.0f;

    // Start is called before the first frame update
    override protected void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        mode = Random.Range(0, 2);
        GetComponent<SpriteRenderer>().sprite = sprites[mode];
        GetComponent<SpriteRenderer>().enabled = true;
        latestY = transform.position.y;
        rb.AddForce(new Vector3(0, Random.Range(550, 600), 0));
    }

    // Update is called once per frame
    override protected void Update()
    {
        gameObject.transform.Rotate(0, 0, rotateSpeed);
        if (latestY > transform.position.y)
        {
            Explode();
        }
        latestY = transform.position.y;
    }

    void Explode() {
        GameObject explosionInstance = Instantiate(explosionEffect, transform.position,
            new Quaternion(0, 0, 0, 1));
        explosionInstance.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

        Bullet firstBullet = Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 1));
        Bullet secondBullet = Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 1));
        Bullet thirdBullet = Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 1));
        Bullet fourthBullet = Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 1));

        switch (mode)
        {
            case 0:
                firstBullet.setSpeed(this.speed * 1.5f);
                secondBullet.setSpeed(this.speed * 1.5f);
                thirdBullet.setSpeed(this.speed * 1.5f);
                fourthBullet.setSpeed(this.speed * 1.5f);

                firstBullet.setDirection(new Vector2(0.0f, 1.0f));
                secondBullet.setDirection(new Vector2(0.0f, -1.0f));
                thirdBullet.setDirection(new Vector2(1.0f, 0.0f));
                fourthBullet.setDirection(new Vector2(-1.0f, 0.0f));
                break;
            case 1:
                firstBullet.setSpeed(this.speed);
                secondBullet.setSpeed(this.speed);
                thirdBullet.setSpeed(this.speed);
                fourthBullet.setSpeed(this.speed);

                firstBullet.setDirection(new Vector2(1.0f, 1.0f));
                secondBullet.setDirection(new Vector2(1.0f, -1.0f));
                thirdBullet.setDirection(new Vector2(-1.0f, 1.0f));
                fourthBullet.setDirection(new Vector2(-1.0f, -1.0f));
                break;
        }

        firstBullet.setVelocity(firstBullet.getDirection() * firstBullet.getSpeed());
        secondBullet.setVelocity(secondBullet.getDirection() * secondBullet.getSpeed());
        thirdBullet.setVelocity(thirdBullet.getDirection() * thirdBullet.getSpeed());
        fourthBullet.setVelocity(fourthBullet.getDirection() * fourthBullet.getSpeed());

        string[] bulletTargets = { "Player" };
        firstBullet.setTargets(bulletTargets);
        secondBullet.setTargets(bulletTargets);
        thirdBullet.setTargets(bulletTargets);
        fourthBullet.setTargets(bulletTargets);

        Destroy(gameObject);
    }
}