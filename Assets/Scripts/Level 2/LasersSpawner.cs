using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersSpawner : ActivatedGameObject
{

    public GameObject laserPrefab;
    private float timer = 0;
    private float waitingTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0;
            Vector3 spawnPos = new Vector3(Random.Range(1.0f, 12.0f),
                transform.position.y, transform.position.z);
            Instantiate(laserPrefab, spawnPos, transform.rotation);

            if (spawnPos.x >= 7.0f)
            {
                spawnPos = new Vector3(Random.Range(1.0f, spawnPos.x - 1.5f),
                    transform.position.y, transform.position.z);
            } else if (spawnPos.x < 7.0f)
            {
                spawnPos = new Vector3(Random.Range(spawnPos.x + 1.5f, 12.0f),
                    transform.position.y, transform.position.z);
            }
            Instantiate(laserPrefab, spawnPos, transform.rotation);

            waitingTime = Random.Range(9.0f, 14.0f);
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
