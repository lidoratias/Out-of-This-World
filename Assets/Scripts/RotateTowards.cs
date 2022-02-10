using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards
{
    public static void rotateTowards(Transform source, Transform target, float speed)
    {
        Vector2 direction = target.position - source.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 15;
        Quaternion rotationTowardsTarget = Quaternion.AngleAxis(angle, Vector3.forward);
        source.rotation = Quaternion.Lerp(source.rotation, rotationTowardsTarget, speed);
    }
}
