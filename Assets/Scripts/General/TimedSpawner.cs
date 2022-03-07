using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : ActivatedGameObject
{

    public GameObject spawnedObject;
    private float timer = 0;
    public float waitingTime = 0.2f;

    public float[] waitingTimeRange;
    public float[] spawnPointRange;

    Vector3 spawnPos;

    public char axis;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0;
            if (axis == 'x')
            {
                spawnPos = new Vector3(Random.Range(spawnPointRange[0], spawnPointRange[1]),
                    transform.position.y, transform.position.z);
            } else if (axis == 'y')
            {
                spawnPos = new Vector3(transform.position.x,
                    Random.Range(spawnPointRange[0], spawnPointRange[1]), transform.position.z);
            }
            Instantiate(spawnedObject, spawnPos, transform.rotation);
            waitingTime = Random.Range(waitingTimeRange[0], waitingTimeRange[1]);
        }
    }

    public override void phaseIn()
    {
        gameObject.SetActive(true);
    }

    public override void phaseOut()
    {
        gameObject.SetActive(false);
    }
}
