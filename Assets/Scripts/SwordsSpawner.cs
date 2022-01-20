using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsSpawner : MonoBehaviour
{

    public GameObject swordPrefab;
    private float timer = 0;
    public float waitingTime = 5.0f;

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
            Instantiate(swordPrefab, transform.position, transform.rotation);
        }
    }
}
