using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected int health = 500;
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
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Cannon Bullet" && anim.GetBool("IsHurt") == false)
        {
            Bullet bullet = hitInfo.GetComponent<Bullet>();
            this.takeDamage(bullet.getDamage());
            Destroy(hitInfo.gameObject);
            anim.SetBool("IsHurt", true);
            Invoke("SetBoolBack", 2.08f);
        }
        else if ((hitInfo.tag == "Hitting Enemy" || hitInfo.tag == "Pirate Skull")
            && anim.GetBool("IsHurt") == false)
        {
            if (hitInfo.gameObject.transform.parent != null)
            {
                GameObject parent = hitInfo.gameObject.transform.parent.gameObject;
                HittingEnemy hittingEnemy = parent.GetComponent<HittingEnemy>();
                this.takeDamage(hittingEnemy.getDamage());
                anim.SetBool("IsHurt", true);
                Invoke("SetBoolBack", 2.08f);
            } else
            {
                HittingEnemy hittingEnemy = hitInfo.GetComponent<HittingEnemy>();
                this.takeDamage(hittingEnemy.getDamage());
                anim.SetBool("IsHurt", true);
                Invoke("SetBoolBack", 2.08f);
            }

        }
    }

    public void SetBoolBack()
    {
        anim.SetBool("IsHurt", false);
    }

}
