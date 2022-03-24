using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : LinearBullet
{
    public Sprite[] sprites;
    public ActivatedGameObjectsHolder[] effects;

    private int potionIdx;
    // Start is called before the first frame update
    protected override void Start()
    {
        string[] targets = { "Player" };
        setTargets(targets);
        potionIdx = Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = sprites[potionIdx];
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
            (potionIdx == 1 && transform.position.y > 4.8f) ||
            (potionIdx == 2 && transform.position.x < -10.1f) )
        {
            //Play Animation and play shattered glass sound
            effects[potionIdx].ActivateAll();
            Destroy(gameObject);
        }
    }
}
