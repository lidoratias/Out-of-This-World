using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHat : Enemy
{

    public Animation anim;

    private float timer;
    private float waitingTime;
    
    //private Vector2 target;

    public Transform firePoint;
    public Transform centerOfRotation;

    public BurstingLaserBeam laserPrefab;
    public GameObject sinsusStar;
    public GameObject straightStar;
    public Bullet[] potionPrefabs;
    public EllipticalMovement em;

    public LevelHandler levelHandler;

    public FlickeringObject top;
    public FlickeringObject bottom;

    private float turningTimer = 0;
    private float waitTillTurn = 0.4f;

    public float bulletsStartingAngle;

    // Start is called before the first frame update
    public override void Start()
    {
        //target = new Vector2(-10, Random.Range(-7.0f, 3.5f));
        waitingTime = 2.0f;
        this.health = 100;
        this.damage = 100;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (this.phase < 4)
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

        }

        //TODO ADD A FEW MORE SHOOTING TYPES - REGULAR BULLETS AND ROTATING BULLETS.
        if (timer >= waitingTime)
        {
            if (levelHandler.getPhase() == 1)
            {
                waitingTime = Random.Range(6.5f, 14.0f);
            } else if (levelHandler.getPhase() == 2)
            {
                waitingTime = Random.Range(1.2f, 2.8f);
            } else if (levelHandler.getPhase() == 3)
            {
                waitingTime = Random.Range(2.0f, 3.0f);
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
            PlayerLinearBullet bullet = hitInfo.GetComponent<PlayerLinearBullet>();
            this.takeDamage(bullet.getDamage());
            Destroy(hitInfo.gameObject);
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
        if (levelHandler.getPhase() == 1)
        {
            BurstingLaserBeam laser = Instantiate(laserPrefab, firePoint.position,
                firePoint.rotation);
            laser.transform.parent = this.firePoint;
            Invoke("drawbackHat", laser.getLifeTime() + laser.getDrawbackLength());
        } else if (levelHandler.getPhase() == 2)
        {
            int typeOfStar = Random.Range(0, 2);
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
        } else if (levelHandler.getPhase() == 3)
        {
            int potionIdx = Random.Range(0, 3);
            Bullet bullet = Instantiate(potionPrefabs[potionIdx], firePoint.position, firePoint.rotation);
            drawbackHat();
        }
    }

    void drawbackHat()
    {
        anim.Play("Witch Hat Drawback");
    }
}
