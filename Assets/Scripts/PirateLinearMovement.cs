using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateLinearMovement : LinearMovement
{
    public float timer = 0f;
    private float waitingTime = 5.0f;
    public Animation myAnimation;
    public AnimationClip burstingSkullAnim;

    void Update()
    {
        timer = timer + Time.deltaTime;
        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.y < minValue)
        {
            movement.Set(0.0f, 1.0f);
        }

        if (pos.y > maxValue)
        {
            movement.Set(0.0f, -1.0f);
        }
        if (timer < waitingTime && myAnimation.isPlaying == false)
        {
            moveCharacter(movement);
        } else
        {
            myAnimation.clip = burstingSkullAnim;
            myAnimation.Play();
            timer = 0f;
        }
    }

    public void setWaitingTime(float waitingTime)
    {
        this.waitingTime = waitingTime;
    }
}
