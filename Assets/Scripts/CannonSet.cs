using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSet : ActivatedGameObject
{

    public Wheel wheel;
    public CannonWeapon cannonWeapon;
    public CannonString cannonString;
    public CannonFire cannonFire;

    private bool phasingOut = false;
    private Vector2 pos;
    private Vector2 phasingOutDirection = new Vector2(-5, 0);

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (!phasingOut)
        {
            if (pos.x >= 0.5)
            {
                wheel.setRotateRight(false);
            }
            else if (pos.x <= 0)
            {
                wheel.setRotateRight(true);
            }
        } else
        {
            transform.Translate(phasingOutDirection * Time.deltaTime);
        }
    }

    public void setPhasingOut(bool phasingOut)
    {
        this.phasingOut = phasingOut;
    }
}
