using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsSpawner : TimedSpawner
{

    private bool isActivated = false;

    // Update is called once per frame
    protected override void Update()
    {
        if (isActivated)
        {
            timer += Time.deltaTime;
            if (timer >= waitingTime)
            {
                timer = 0;
                if (axis == 'x')
                {
                    spawnPos = new Vector3(Random.Range(spawnPointRange[0], spawnPointRange[1]),
                        transform.position.y, transform.position.z);
                }
                else if (axis == 'y')
                {
                    spawnPos = new Vector3(transform.position.x,
                        Random.Range(spawnPointRange[0], spawnPointRange[1]), transform.position.z);
                }
                Instantiate(spawnedObjects[0], spawnPos, transform.rotation);
                waitingTime = Random.Range(waitingTimeRange[0], waitingTimeRange[1]);
            }
        }
    }

    public void setIsActivated(bool isActivated)
    {
        this.isActivated = isActivated;
    }
}
