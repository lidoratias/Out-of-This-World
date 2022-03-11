using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 100;

    protected int phase = 1;

    private string target;
    public Animation myAnimation;
    public string flickerAnimName;

    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

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

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player Bullet")
        {
            PlayerLinearBullet bullet = hitInfo.GetComponent<PlayerLinearBullet>();
            this.takeDamage(bullet.getDamage());
            Destroy(hitInfo.gameObject);
            if (myAnimation != null)
            {
                myAnimation.Play(flickerAnimName);
            }
        }
    }

    public int getHealth()
    {
        return this.health;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setPhase(int phase)
    {
        this.phase = phase;
    }


}
