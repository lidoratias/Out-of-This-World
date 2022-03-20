using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : HittingEnemy
{
    public Animation anim;
    public AnimationClip heartBeatClip;
    private float targetY;
    private int numOfBeats;

    // Update is called once per frame
    override protected void Update()
    {
        if (transform.position.y > targetY)
        {
            Invoke("heartBeat", 0.5f);
        }
    }

    void heartBeat()
    {
        anim.Play(anim.clip.ToString());
        numOfBeats--;
        if (numOfBeats > 0)
        {
            Invoke("heartBeat", anim.clip.length);
        }
    }
}
