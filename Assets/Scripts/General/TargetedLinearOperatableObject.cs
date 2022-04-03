using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedLinearOperatableObject : LinearOperatableObject
{
    public Transform target;
    private Vector3 targetCapturedPos;

    public override void Operate()
    {
        Activate();
    }

    protected override void Activate()
    {
        //Vector2 directionTowardsTarget = new Vector2(target.position.x - gameObject.transform.position.x,
        //    target.position.y - transform.position.y);
        targetCapturedPos = target.position;
        //lm.setMovement(directionTowardsTarget);
        lm.enabled = true;
    }

    public void Update()
    {
        if (Mathf.Abs(targetCapturedPos.x - transform.position.x) < 0.3f 
            && Mathf.Abs(targetCapturedPos.y - transform.position.y) < 0.3f
            && lm.enabled == true)
        {
            Disactivate();
            notifyObservers();
        } else if (lm.enabled == true)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, targetCapturedPos,
                speed);
            this.transform.position = newPos;
        }
    }

}
