using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsSpawner : TimedSpawner
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

                int randomIndex = Random.Range(1, sumOfChances + 1);
                int collectedSum = 0;
                GameObject spawnedObject = null;
                for (int i = 0; i < chancesForEachObject.Length; i++)
                {
                    collectedSum += chancesForEachObject[i];
                    if (randomIndex <= collectedSum)
                    {
                        spawnedObject = spawnedObjects[i];
                        break;
                    }
                }
                Instantiate(spawnedObject, spawnPos, transform.rotation);
                waitingTime = Random.Range(waitingTimeRange[0], waitingTimeRange[1]);
            }
        }
    }

    public void setIsActivated(bool isActivated)
    {
        this.isActivated = isActivated;
    }
}
