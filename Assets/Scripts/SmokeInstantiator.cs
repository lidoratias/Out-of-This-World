using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SmokeInstantiator : MonoBehaviour
{

    public float timer = 0f;
    public float waitingTime = 0.3f;
    public GameObject[] smokeClouds;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateSmoke();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= waitingTime)
        {
            InstantiateSmoke();
            timer = 0f;
        }
    }

    void InstantiateSmoke()
    {
        Random rnd = new Random();
        GameObject newSmokeCloud = Instantiate(this.smokeClouds[rnd.Next(0, 3)], transform.position, transform.rotation) as GameObject;  // instatiate the object
        newSmokeCloud.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }
}
