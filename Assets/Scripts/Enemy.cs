using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 100;
    private string target;
    
    void Start()
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
        }
    }


}
