using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHat : MonoBehaviour
{

    public Animation anim;

    private float timer;
    private float waitingTime;
    
    private Vector2 target;

    public Transform firePoint;
    public BurstingLaserBeam laserPrefab;
    public GameObject sinsusStar;
    public GameObject straightStar;

    public LevelHandler levelHandler;

    public FlickeringObject top;
    public FlickeringObject bottom;

    private float turningTimer = 0;
    private float waitTillTurn = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(-10, Random.Range(-7.0f, 3.5f));
        waitingTime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        turningTimer += Time.deltaTime;

        if (Mathf.Abs(Mathf.Abs(transform.position.y) - 2.9f) <= 0.1f 
            && turningTimer >= waitTillTurn)
        {
            int generatedInt = Random.Range(0, 3);
            if (generatedInt == 1)
            {
                gameObject.GetComponent<EllipticalMovement>().turnDirection();
            }
            turningTimer = 0;
        }

        //TODO ADD A FEW MORE SHOOTING TYPES - REGULAR BULLETS AND ROTATING BULLETS.
        if (timer >= waitingTime)
        {
            if (levelHandler.getPhase() == 1)
            {
                waitingTime = Random.Range(6.5f, 14.0f);
            } else if (levelHandler.getPhase() == 2)
            {
                waitingTime = Random.Range(2.0f, 4.0f);
            }
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
        if (levelHandler.getPhase() == 1)
        {
            BurstingLaserBeam laser = Instantiate(laserPrefab, firePoint.position,
                firePoint.rotation);
            laser.transform.parent = this.firePoint;
            Invoke("drawbackHat", laser.getLifeTime() + laser.getDrawbackLength());
        } else if (levelHandler.getPhase() == 2)
        {
            int typeOfStar = Random.Range(0, 7);
            if (typeOfStar == 0)
            {
                Instantiate(sinsusStar, firePoint.position, firePoint.rotation);
            } else if (typeOfStar > 0)
            {
                GameObject currentStar = Instantiate(straightStar, firePoint.position, firePoint.rotation);
                Wheel wheel = currentStar.AddComponent<Wheel>() as Wheel;
                wheel.setPace(5);
            }
            drawbackHat();
        }
    }

    void drawbackHat()
    {
        anim.Play("Witch Hat Drawback");
    }
}
