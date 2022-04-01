using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedFollow : BasicMovement
{

    public string targetTag;
    protected GameObject target;
    protected Vector3 currentTargetPos;

    protected bool currentTargetPosUpdated = false;

    public float timeBetweenSteps;
    public float distanceDelta;
    protected float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag(targetTag);
    }

    // Update is called once per frame
    protected virtual void Update()
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
