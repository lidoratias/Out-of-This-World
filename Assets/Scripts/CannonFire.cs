using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{

    public Animator anim;

    public void setSpeed(float waitingTime)
    {
        anim.speed = 0.5f / waitingTime;
    }

    /*public void PlayAnimation()
    {
        fireAnimation.Play("Moving Cannon Fire - half a second");
    }*/
}
