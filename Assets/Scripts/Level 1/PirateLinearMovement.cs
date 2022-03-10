using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateLinearMovement : LinearMovement
{
    public Vector3 startPos;

    private float timer = 0f;
    private float waitingTime = 5.0f;
    public Animation myAnimation;
    public AnimationClip burstingSkullAnim;

    private bool isPhasedOut = false;
    private Vector2 phasingOutDirection = new Vector2(1, 0);
    public float phasingOutSpeed;

    void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        if (!isPhasedOut)
        {
            timer = timer + Time.deltaTime;
            //Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
            //Debug.Log(pos.x);
            //Debug.Log(pos.y);

            if (transform.position.y < minYValue)
            {
                movement *= -1;
            }

            if (transform.position.y > maxYValue)
            {
                movement *= -1;
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
