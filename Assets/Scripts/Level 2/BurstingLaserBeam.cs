using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstingLaserBeam : StaticLaserBeam
{
    protected override void Start()
    {
        this.waitingTime = 0;
        phaseIn();
    }

    public override void phaseIn()
    {
        timer = 0;
        phase = 0;
        gameObject.SetActive(true);
        transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
    }
}
