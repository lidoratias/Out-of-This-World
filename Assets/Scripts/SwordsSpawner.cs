using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsSpawner : MonoBehaviour
{

    public GameObject swordPrefab;
    private float timer = 0;
    public float waitingTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= waitingTime)
        {
            timer = 0;
            Vector3 spawnPos = new Vector3(Random.Range(-9.5f, 9.5f),
                transform.position.y, transform.position.z);
            Instantiate(swordPrefab, spawnPos, transform.rotation);
        }
    }
}
