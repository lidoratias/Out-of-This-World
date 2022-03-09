using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSet : ActivatedGameObject
{

    public Wheel wheel;
    public CannonWeapon cannonWeapon;
    public CannonString cannonString;
    public CannonFire cannonFire;

    private Vector2 pos;
    private Vector2 phasingOutDirection = new Vector2(1, 0);

    public float phasingOutSpeed;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (!this.isPhasingOut)
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
            transform.Translate(phasingOutDirection * phasingOutSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer >= 5.0f)
            {
                Destroyer.Destroy(gameObject);
            }
        }
    }

    public override void phaseOut()
    {
        this.isPhasingOut = true;
        this.cannonWeapon.phaseOut();
        GetComponent<LinearMovement>().enabled = false;
        timer = 0;
    }
}
