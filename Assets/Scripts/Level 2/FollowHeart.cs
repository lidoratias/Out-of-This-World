using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHeart : TimedFollow
{

    private bool isActivated = false;

    public LinearMovement lm;

    // Update is called once per frame
    protected override void Update()
    {
        if (isActivated)
        {
            if (timer < timeBetweenSteps)
            {
                timer += Time.deltaTime;
            }
            else
            {
                if (!currentTargetPosUpdated)
                {
                    currentTargetPos = target.transform.position;
                    currentTargetPosUpdated = true;
                }

                Vector3 newPos = Vector3.MoveTowards(transform.position, currentTargetPos,
                    distanceDelta);
                this.transform.position = newPos;

                if ((newPos - currentTargetPos).magnitude < 0.01f)
                {
                    timer = 0;
                    currentTargetPosUpdated = false;
                }
            }

        }
    }

    public void setIsActivated(bool isActivated)
    {
        this.isActivated = isActivated;

        if (!isActivated)
        {
            //The Object is being shutdown
            lm.setMovement(new Vector2(1, 0));
            lm.setSpeed(10);
        }
    }
}
