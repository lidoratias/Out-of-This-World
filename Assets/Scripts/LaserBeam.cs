using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : HittingEnemy
{

    private float timer = 0;
    private float waitingTime = 1.5f;

    private bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            timer += Time.deltaTime;
        }

        if (timer >= waitingTime)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Wheel>().enabled = true;
        }
    }

    public void phaseIn()
    {
        timer = 0;
        isActivated = true;
        gameObject.SetActive(true);
    }

    public void phaseOut()
    {
        gameObject.SetActive(false);
    }
}
