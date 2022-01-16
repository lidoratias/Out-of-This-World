using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonString : MonoBehaviour
{

    public Animation shortenAnimation;

    public void PlayAnimation(float length)
    {
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
    }
}
