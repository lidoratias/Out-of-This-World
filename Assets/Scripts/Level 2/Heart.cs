using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : HittingEnemy
{
    public Animation anim;
    //public AnimationClip heartBeatClip;
    public LinearMovement linearMovement;
    private float targetY;
    private int numOfBeats;
    private bool isBeating = false;

    void Awake()
    {
        targetY = Random.Range(-3.5f, 5.5f);
        numOfBeats = Random.Range(2, 6);
    }
    // Update is called once per frame
    override protected void Update()
    {
        if (transform.position.y > targetY && !isBeating)
        {
            isBeating = true;
            linearMovement.enabled = false;
            Invoke("heartBeat", 0.2f);
        }

        if (numOfBeats == 0 && !anim.isPlaying)
        {
            linearMovement.enabled = true;
        }
    }

    void heartBeat()
    {
        anim.Play();
        numOfBeats--;
        if (numOfBeats > 0)
        {
            Invoke("heartBeat", anim.clip.length - 0.5f);
        }
    }
}
