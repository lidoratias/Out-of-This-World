using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected int health = 1000;

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

    public void Update()
    {
        //Debug.Log(this.health);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Cannon Bullet")
        {
            CannonDirectedBullet bullet = hitInfo.GetComponent<CannonDirectedBullet>();
            this.takeDamage(bullet.getDamage());
            Destroy(hitInfo.gameObject);
        }
        else if (hitInfo.tag == "Pirate Skull")
        {
            GameObject parent = hitInfo.gameObject.transform.parent.gameObject;
            PirateSkull pirateSkull = parent.GetComponent<PirateSkull>();
            this.takeDamage(pirateSkull.getDamage());
        }
    }


}
