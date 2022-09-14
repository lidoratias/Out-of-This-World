using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionClickersSpawner : TimedSpawner
{
    protected override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0;
            if (axis == 'x')
            {
                spawnPos = new Vector3(Random.Range(spawnPointRange[0], spawnPointRange[1]),
                    transform.position.y, -2f);
            }
            else if (axis == 'y')
            {
                spawnPos = new Vector3(transform.position.x,
                    Random.Range(spawnPointRange[0], spawnPointRange[1]), -2f);
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
            int rand = Random.Range(0, 100);
            if (rand % 2 == 0)
            {
                this.axis = 'x';
                spawnPointRange[0] = -8f;
                spawnPointRange[1] = 8f;
                transform.position = new Vector3(transform.position.x, -6.1f, -2f);
            }
            else
            {
                this.axis = 'y';
                spawnPointRange[0] = -4.5f;
                spawnPointRange[1] = 4.5f;
                transform.position = new Vector3(-11f, transform.position.y, -2f);
            }
        }
    }
}
