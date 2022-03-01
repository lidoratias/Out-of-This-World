using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHat : MonoBehaviour
{

    public Animation anim;

    private float timer;
    private float waitingTime;

    private float turningTimer;
    private float waitTillTurn;

    //private float shootingTimer;
    //private float shootingWaitingTime = 0.25f;
    
    private Vector2 target;

    public Transform firePoint;
    public BurstingLaserBeam laserPrefab;

    public WitchHatPart top;
    public WitchHatPart bottom;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(-10, Random.Range(-7.0f, 3.5f));
        waitingTime = 2.0f;
        waitTillTurn = Random.Range(4.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        turningTimer += Time.deltaTime;

        if (turningTimer >= waitTillTurn)
        {
            gameObject.GetComponent<EllipticalMovement>().turnDirection();
            waitTillTurn = Random.Range(4.0f, 10.0f);
            turningTimer = 0;
        }

        if (timer >= waitingTime)
        {
            waitingTime = Random.Range(6.5f, 14.0f);
            anim.Play("Witch Hat Shot");
            timer = 0;
            Invoke("Shoot", 0.25f);
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
        BurstingLaserBeam laser = Instantiate(laserPrefab, firePoint.position, 
            firePoint.rotation);
        laser.transform.parent = this.firePoint;
        Invoke("drawbackHat", laser.getLifeTime() + laser.getDrawbackLength());
        /*bullet.setDirection(direction);
        string[] bulletTargets = { "Player" };
        bullet.setTargets(bulletTargets);
        target = new Vector2(-10, Random.Range(-7.0f, 3.5f));*/
    }

    void drawbackHat()
    {
        anim.Play("Witch Hat Drawback");
    }
}
