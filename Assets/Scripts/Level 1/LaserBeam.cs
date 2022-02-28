using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : HittingEnemy
{

    protected float timer = 0;
    protected float waitingTime = 1.5f;

    protected bool isActivated = false;

    // Update is called once per frame
    override protected void Update()
    {
        if (isActivated)
        {
            timer += Time.deltaTime;
        }

        if (timer >= waitingTime)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Wheel>().enabled = true;
        }
    }

    public virtual void phaseIn()
    {
        timer = 0;
        isActivated = true;
        gameObject.SetActive(true);
    }

    public virtual void phaseOut()
    {
        gameObject.SetActive(false);
    }
}
