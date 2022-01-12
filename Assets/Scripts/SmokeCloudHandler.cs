using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCloudHandler : MonoBehaviour
{
    public float timer = 0;
    private float waitingTime = 0.3f;
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
