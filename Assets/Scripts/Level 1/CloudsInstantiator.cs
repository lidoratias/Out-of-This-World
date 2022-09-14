using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CloudsInstantiator : MonoBehaviour
{

    public float timer = 0f;
    public float waitingTime = 0.3f;
    public GameObject[] smokeClouds;
    public float size;

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
        Vector3 objPosition = new Vector3(transform.position.x, transform.position.y + UnityEngine.Random.Range(-1f, 1f),
            transform.position.z);
        GameObject newSmokeCloud = Instantiate(this.smokeClouds[rnd.Next(0, smokeClouds.Length)],
            objPosition, transform.rotation) as GameObject;  // instatiate the object
        newSmokeCloud.transform.localScale = new Vector3(size, size, size);
    }
}
