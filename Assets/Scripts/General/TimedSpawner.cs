using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : ActivatedGameObject
{

    public GameObject[] spawnedObjects;
    public int[] chancesForEachObject;
    protected int sumOfChances = 0;

    protected float timer = 0;
    protected float waitingTime = 0.2f;

    public float[] waitingTimeRange;
    public float[] spawnPointRange;

    protected Vector3 spawnPos;

    public char axis;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0, 0, 0);

        for (int i = 0; i < chancesForEachObject.Length; i++)
        {
            sumOfChances += chancesForEachObject[i];
        }
    }

    // Update is called once per frame
    protected virtual void Update()
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

    public override void phaseIn()
    {
        gameObject.SetActive(true);
    }

    public override void phaseOut()
    {
        gameObject.SetActive(false);
    }
}
