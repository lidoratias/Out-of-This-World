using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLaserBeam : LaserBeam
{

    public Animation anim;

    public string burstAnimName;
    public string drawbackAnimName;
    public string flickerAnimName;

    protected int phase = 0;
    protected float lifeTime = 5.0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        this.waitingTime = 2.0f;
        phaseIn();
    }

    override protected void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitingTime && phase == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            anim.Play(burstAnimName);
            phase = 1;
            timer = 0;
        }

        if (timer >= lifeTime && phase == 1)
        {
            anim.Play(drawbackAnimName);
            phase = 2;
        }

        if (timer >= lifeTime + 0.5f && phase == 2)
        {
            Destroy(gameObject);
        }
    }

    public override void phaseIn()
    {
        timer = 0;
        phase = 0;
        gameObject.SetActive(true);
        anim.Play("Flickering Red Laser Beam");
    }

    public override void phaseOut()
    {
        gameObject.SetActive(false);
    }

    public float getLifeTime()
    {
        return this.lifeTime;
    }

    public float getDrawbackLength()
    {
        return 0.5f;
    }
}
