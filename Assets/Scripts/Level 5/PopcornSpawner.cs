using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornSpawner : TimedSpawner
{

    protected override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0;
            float spawnX = Random.Range(spawnPointRange[0], spawnPointRange[1]);
            spawnPos = new Vector3(spawnX,
                transform.position.y, transform.position.z);
  
            Instantiate(spawnedObjects[0], spawnPos, transform.rotation);
            waitingTime = Random.Range(waitingTimeRange[0], waitingTimeRange[1]);
        }
    }
}
