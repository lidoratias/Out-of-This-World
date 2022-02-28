using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected int health = 500;
    public Animator anim;
    private ArrayList hurtingObjectsTags = new ArrayList();

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

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*if (hurtingObjectsTags.Contains(hitInfo.tag) && anim.GetBool("IsHurt") == false)
        {
            Bullet bullet = hitInfo.GetComponent<Bullet>();
            this.takeDamage(bullet.getDamage());
            Destroy(hitInfo.gameObject);
            anim.SetBool("IsHurt", true);
            Invoke("SetBoolBack", 2.08f);
        }
        else*/ if (hurtingObjectsTags.Contains(hitInfo.tag) && anim.GetBool("IsHurt") == false)
        {
            if (hitInfo.gameObject.transform.parent != null
                && hitInfo.gameObject.transform.parent.GetComponent<HittingEnemy>() != null)
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
