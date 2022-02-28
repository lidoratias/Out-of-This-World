using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHat : MonoBehaviour
{

    public Animation anim;

    private float timer;
    public float waitingTime;

    private float shootingTimer;
    private float shootingWaitingTime = 0.25f;
    
    private Vector2 target;

    public Transform firePoint;
    public Bullet bulletPrefab;

    public WitchHatPart top;
    public WitchHatPart bottom;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(-10, Random.Range(-7.0f, 3.5f));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            anim.Play("Witch Hat Shot");
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingWaitingTime)
            {
                Shoot();
                shootingTimer = 0;
                timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player Bullet")
        {
            top.flicker();
            bottom.flicker();
            Invoke("unflickerHatParts", 0.1f);
        }
    }

    void unflickerHatParts()
    {
        top.unflicker();
        bottom.unflicker();
    }

    void Shoot()
    {
        Vector2 direction = new Vector2(target.x - transform.position.x,
            target.y - transform.position.y);
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.setDirection(direction);
        string[] bulletTargets = { "Player" };
        bullet.setTargets(bulletTargets);
        target = new Vector2(-10, Random.Range(-7.0f, 3.5f));
    }
}
