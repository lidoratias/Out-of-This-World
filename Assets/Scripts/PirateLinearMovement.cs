using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateLinearMovement : LinearMovement
{
    public float timer = 0f;
    private float waitingTime = 5.0f;
    public Animation myAnimation;
    public AnimationClip burstingSkullAnim;

    private bool isPhasedOut = false;
    private Vector2 phasingOutDirection = new Vector2(1, 0);
    public float phasingOutSpeed;

    void Update()
    {
        if (!isPhasedOut)
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
            }
            else
            {
                myAnimation.clip = burstingSkullAnim;
                myAnimation.Play();
                timer = 0f;
            }
        } else
        {
            timer = timer + Time.deltaTime;
            transform.Translate(phasingOutDirection * phasingOutSpeed * Time.deltaTime);
            if (timer >= 5.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void setWaitingTime(float waitingTime)
    {
        this.waitingTime = waitingTime;
    }

    public void phaseOut()
    {
        this.isPhasedOut = true;
        this.timer = 0;
    }
}
