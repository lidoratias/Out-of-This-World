using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{

    public Animator anim;

    private float timer = 0;
    public float waitingTime = 0.1f;

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
