using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSkull : ActivatedGameObject
{

    private Vector2 phasingInDirection = new Vector2(-1, 0);
    public float phasingInSpeed = 1.0f;

    public LaserBeam[] laserBeams;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isPhasingIn)
        {
            if (transform.position.x > -1.3)
            {
                transform.Translate(phasingInDirection * phasingInSpeed * Time.deltaTime);
                if (transform.position.x <= -1.3)
                {
                    for (int i = 0; i < laserBeams.Length; i++)
                    {
                        laserBeams[i].phaseIn();
                    }
                    gameObject.GetComponent<CircularMovement>().enabled = true;
                }
            }
        }
    }

    public override void phaseIn()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < laserBeams.Length; i++)
        {
            laserBeams[i].phaseOut();
        }
        this.isPhasingIn = true;
    }
}
