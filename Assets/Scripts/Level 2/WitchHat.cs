using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHat : MonoBehaviour
{

    public Animation anim;
    private float timer;
    public float waitingTime;

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
            anim.Play("Witch Hat Shot");
            timer = 0;
        }
    }
}
