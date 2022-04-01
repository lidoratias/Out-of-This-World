using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : LinearBullet
{
    public Sprite[] sprites;
    //public ActivatedGameObjectsHolder[] effects;

    private int potionIdx;
    private float potionEffectsLength = 40;

    FollowHeart hf;
    HeartsSpawner hs;
    EyesCollection eyes;

    protected override void Start()
    {
        string[] targets = { "Player" };
        setTargets(targets);
        //potionIdx = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[potionIdx];

        if (potionIdx == 1)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
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
                    //effects[potionIdx].ActivateAll();
                    eyes = (EyesCollection)Object.FindObjectOfType(typeof(EyesCollection));
                    eyes.setIsActivated(true);
                    Destroy(gameObject);
                    break;
            }
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
        }
    }

    public void setPotionIdx(int idx)
    {
        this.potionIdx = idx;
    }
}
