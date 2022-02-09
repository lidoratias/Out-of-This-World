using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSet : MonoBehaviour
{

    public Wheel wheel;
    public CannonWeapon cannonWeapon;
    public CannonString cannonString;
    public CannonFire cannonFire;

    private Vector2 pos;

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x >= 0.5)
        {
            wheel.setRotateRight(false);
        } else if (pos.x <= 0)
        {
            wheel.setRotateRight(true);
        }
    }
}
