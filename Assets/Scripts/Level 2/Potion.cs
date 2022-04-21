using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : LinearBullet
{
    public Sprite[] sprites;
    public GameObject[] explosions;
    public Vector3 explosionSize;

    private int potionIdx;
    private float potionEffectsLength = 40;

    FollowHeart hf;
    HeartsSpawner hs;
    EyesCollection eyes;
    DropsSpawner ds;

    protected override void Start()
    {
        string[] targets = { "Player" };
        setTargets(targets);
        GetComponent<SpriteRenderer>().sprite = sprites[potionIdx];

        if (potionIdx == 1)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            this.speed = 20;
        } else if (potionIdx == 2)
        {
            GetComponent<Rigidbody2D>().gravityScale = -1;
        }
        this.speed = Random.Range(5, 13);
        rb.velocity = this.direction * this.speed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        checkLocation();
    }

    void checkLocation()
    {
        if ((potionIdx == 0 && transform.position.y < -4.8f) ||
            (potionIdx == 2 && transform.position.y > 4.8f) ||
            (potionIdx == 1 && transform.position.x < -10.1f) )
        {
            Vector3 explosionPosition = new Vector3(0, 0, 0);
            if (potionIdx == 1)
            {
                explosionPosition = new Vector3(-8.5f, transform.position.y, transform.position.z);
            } else if (potionIdx == 0)
            {
                explosionPosition = new Vector3(transform.position.x, -3.5f, transform.position.z);
            } else if (potionIdx == 2)
            {
                explosionPosition = new Vector3(transform.position.x, 3.5f, transform.position.z);
            }
            GameObject explosionInstance = Instantiate(explosions[potionIdx], explosionPosition, transform.rotation);
            explosionInstance.transform.localScale = explosionSize;
            
            switch (potionIdx)
            {
                case 0:
                    hf = (FollowHeart)Object.FindObjectOfType(typeof(FollowHeart));
                    hf.setIsActivated(true);
                    hs = (HeartsSpawner)Object.FindObjectOfType(typeof(HeartsSpawner));
                    hs.setIsActivated(true);
                    break;
                case 1:
                    //Play Animation and play shattered glass sound
                    eyes = (EyesCollection)Object.FindObjectOfType(typeof(EyesCollection));
                    eyes.setIsActivated(true);
                    Destroy(gameObject);
                    break;
                case 2:
                    ds = (DropsSpawner)Object.FindObjectOfType(typeof(DropsSpawner));
                    ds.setIsActivated(true);
                    break;
            }
            Destroy(gameObject);
        }
    }

    public void setPotionEffectsLength (float length)
    {
        this.potionEffectsLength = length;
    }

    public void cancelEffect()
    {
        if (potionIdx == 0)
        {
            hf.setIsActivated(false);
            hs.setIsActivated(false);
        } else if (potionIdx == 1)
        {
            eyes.setIsActivated(false);
        } else if(potionIdx == 2)
        {
            ds.setIsActivated(false);
        }
    }

    public void setPotionIdx(int idx)
    {
        this.potionIdx = idx;
    }
}
