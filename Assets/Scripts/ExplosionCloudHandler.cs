using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCloudHandler : MonoBehaviour
{

    public float timer = 0;
    public float waitingTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            Destroy(gameObject);
        }
    }
}
