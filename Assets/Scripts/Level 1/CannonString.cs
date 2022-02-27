using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonString : MonoBehaviour
{

    public Animator anim;

    public void setSpeed(float waitingTime)
    {
        anim.speed = 0.5f / waitingTime;
    }

    /*public void PlayAnimation()
    {
        shortenAnimation.Play("String Shorten - half a second");

        switch (length)
        {
            case 4.0f:
                shortenAnimation.Play("String Shorten - 4 seconds");
                break;
            case 5.0f:
                shortenAnimation.Play("String Shorten - 5 seconds");
                break;
            case 6.0f:
                shortenAnimation.Play("String Shorten - 6 seconds");
                break;
        }
    }*/
}
