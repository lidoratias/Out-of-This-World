using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed = 3.0f;
    public int damage = 20;
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
                if (hitInfo.tag == "Enemy")
                {
                    Enemy enemy = hitInfo.GetComponent<Enemy>();
                    enemy.takeDamage(damage);
                    Destroy(gameObject);
                }
                break;
            case "Player":
                if (hitInfo.tag == "Player")
                {
                    Player player = hitInfo.GetComponent<Player>();
                    player.takeDamage(damage);
                    Destroy(gameObject);
                }
                break;
        }

    }

}
