using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsSpawner : ActivatedGameObject
{

    public float waitingTime;
    private float timer;
    public GameObject barrel;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0;
            Vector3 instancePos = new Vector3(transform.position.x - Random.Range(0, 5),
                transform.position.y, transform.position.z);
            Instantiate(barrel, instancePos, new Quaternion(0, 0, 0, 1));
        }
    }
}
