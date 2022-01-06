using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3.0f;
    public int damage = 20;
    public Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject targetGameObject = GameObject.Find("Player");
        Vector2 direction = targetGameObject.transform.position - transform.position;
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }

}
