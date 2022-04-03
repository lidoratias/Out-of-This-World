using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesCollection : TurnBasedCollection
{
    private bool isActivated = false;
    private bool isInPlace = false;

    public Transform target;

    public LinearMovement lm;

    protected override void Update()
    {
        if (isActivated)
        {
            if (Mathf.Abs(transform.position.x - target.position.x) < 0.1f
                && Mathf.Abs(transform.position.y - target.position.y) < 0.1f)
            {
                isInPlace = true;
            }
            else if (!isInPlace)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position,
                    0.015f);
            }

            if (isInPlace)
            {
                if (turnsTimer < waitingTimeBetweenTurns)
                {
                    turnsTimer += Time.deltaTime;
                }
                else if (!alreadyCalled)
                {
                    //In Turn
                    operatableGameObjects[order[currentOrderIdx]].Operate();
                    alreadyCalled = true;
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
            lm.setMovement(new Vector2(0, 1));
            lm.setSpeed(20);
        }
    }
}
