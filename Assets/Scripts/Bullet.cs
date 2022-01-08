using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed = 3.0f;
    protected int damage = 20;
    public Rigidbody2D rb;
    protected Vector2 direction;
    protected string target;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        switch (target)
        {
            case "Enemy":
                Enemy enemy = hitInfo.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.takeDamage(damage);
                    Destroy(gameObject);
                }
                break;
            case "Player":
                Debug.Log("in case of player target");
                Player player = hitInfo.GetComponent<Player>();
                if (player != null)
                {
                    player.takeDamage(damage);
                    Destroy(gameObject);
                }
                break;
        }

    }

}
