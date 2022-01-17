using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{

    public Animation fireAnimation;

    public void PlayAnimation(float length)
    {
        switch (length)
        {
            case 4.0f:
                fireAnimation.Play("Moving Cannon Fire - 4 Seconds");
                break;
            case 5.0f:
                fireAnimation.Play("Moving Cannon Fire - 5 Seconds");
                break;
        }
    }
}
