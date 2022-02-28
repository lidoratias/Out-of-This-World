using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLaserBeam : LaserBeam
{

    public Animation anim;
    private int phase = 0;

    // Start is called before the first frame update
    void Start()
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
            anim.Play("Bursting Red Laser Beam");
            phase = 1;
            timer = 0;
            waitingTime = 5;
        }

        if (timer >= waitingTime && phase == 1)
        {
            anim.Play("Destroy Red Laser Beam");
            phase = 2;
        }

        if (timer >= waitingTime + 0.5f && phase == 2)
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
}
