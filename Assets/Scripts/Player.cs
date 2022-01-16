using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected int health = 1000;
    public Animator anim;

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
        if (hitInfo.tag == "Cannon Bullet" && anim.GetBool("IsHurt") == false)
        {
            CannonDirectedBullet bullet = hitInfo.GetComponent<CannonDirectedBullet>();
            this.takeDamage(bullet.getDamage());
            Destroy(hitInfo.gameObject);
            anim.SetBool("IsHurt", true);
            Invoke("SetBoolBack", 2.08f);
        }
        else if (hitInfo.tag == "Pirate Skull" && anim.GetBool("IsHurt") == false)
        {
            GameObject parent = hitInfo.gameObject.transform.parent.gameObject;
            PirateSkull pirateSkull = parent.GetComponent<PirateSkull>();
            this.takeDamage(pirateSkull.getDamage());
            anim.SetBool("IsHurt", true);
            Invoke("SetBoolBack", 2.08f);
        }
    }

    public void SetBoolBack()
    {
        anim.SetBool("IsHurt", false);
    }

}
