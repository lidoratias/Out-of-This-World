using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected int health = 500;
    public Animator anim;
    private ArrayList hurtingObjectsTags = new ArrayList();
    private bool isFlickering = false;

    private float timer = 0;
    //public float timeBetweenFlickers;

    public float flickeringWaitingTime;

    public FlickeringObject flickeringObject;

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }

    public void Start()
    {
        hurtingObjectsTags.Add("Bullet");
        hurtingObjectsTags.Add("Hitting Enemy");
        hurtingObjectsTags.Add("BlockingHittingEnemy");
        hurtingObjectsTags.Add("IgnorableBullet");
    }

    void Update()
    {
        if (isFlickering)
        {
            timer += Time.deltaTime;
        }

        if (isFlickering && timer <= flickeringWaitingTime)
        {
            if (!flickeringObject.getIsOn())
            {
                unflicker();
            }
            else
            {
                flicker();
            }
        }

        if (timer > flickeringWaitingTime)
        {
            timer = 0;
            flickeringObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,
                1.0f);
            flickeringObject.setIsOn(true);
            isFlickering = false;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hurtingObjectsTags.Contains(hitInfo.tag) && !isFlickering)
        {
            if (hitInfo.gameObject.transform.parent != null
                && hitInfo.gameObject.transform.parent.GetComponent<HittingEnemy>() != null)
            {
                GameObject parent = hitInfo.gameObject.transform.parent.gameObject;
                HittingEnemy hittingEnemy = parent.GetComponent<HittingEnemy>();
                this.takeDamage(hittingEnemy.getDamage());
                isFlickering = true;

            } else
            {
                HittingEnemy hittingEnemy = hitInfo.GetComponent<HittingEnemy>();
                this.takeDamage(hittingEnemy.getDamage());
                isFlickering = true;
            }

        }
    }

    public void flicker()
    {
        Color c = flickeringObject.GetComponent<SpriteRenderer>().color;
        if (c.a - 0.005f > 0.2f)
        {
            flickeringObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,
                c.a - 0.005f);
        }
        else
        {
            flickeringObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,
                0.2f);
            flickeringObject.setIsOn(false);
        }
    }

    public void unflicker()
    {
        Color c = flickeringObject.GetComponent<SpriteRenderer>().color;
        if (c.a + 0.005f < 1.0f)
        {
            flickeringObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,
                c.a + 0.005f);
        }
        else
        {
            flickeringObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,
                1.0f);
            flickeringObject.setIsOn(true);
        }
    }
}
