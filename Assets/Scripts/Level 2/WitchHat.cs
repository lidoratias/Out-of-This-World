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
    public EllipticalMovement em;

    public Potion potionPrefab;
    private List<int> potionIdxes = new List<int>();
    public float potionEffectLength;
    private float potionTimer = 0;
    private Potion potionInstance;
    private bool potionLaunched = false;

    public LevelHandler levelHandler;

    public FlickeringObject top;
    public FlickeringObject bottom;

    private float turningTimer = 0;
    private float waitTillTurn = 0.4f;

    public float bulletsStartingAngle;

    // Start is called before the first frame update
    public override void Start()
    {
        fillPotions();

        //target = new Vector2(-10, Random.Range(-7.0f, 3.5f));
        waitingTime = 2.0f;
        //this.health = 100;
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

        if (this.potionInstance != null)
        {
            potionLaunched = true;
        } else if (potionLaunched)
        {
            potionTimer += Time.deltaTime;
            if (potionTimer > potionEffectLength)
            {
                this.potionInstance.cancelEffect();
                potionTimer = 0;
                potionLaunched = false;
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
                // +8 to let the effect fade away
                waitingTime = potionEffectLength + 8;
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

    void fillPotions()
    {
        for (int i = 0; i < 3; i++)
        {
            potionIdxes.Add(i);
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
            if (potionIdxes.Count == 0)
            {
                fillPotions();
            }
            this.potionInstance = Instantiate(potionPrefab, firePoint.position, firePoint.rotation);
            int potionIdx = potionIdxes[Random.Range(0, potionIdxes.Count)];
            potionIdxes.Remove(potionIdx);
            this.potionInstance.setPotionIdx(potionIdx);
            drawbackHat();
        }
    }

    void drawbackHat()
    {
        anim.Play("Witch Hat Drawback");
    }
}
