using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSkulls : MonoBehaviour
{

    public PirateLinearMovement skullOne;
    public PirateLinearMovement skullTwo;
    private float timer = 0;
    private float waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        generateRandomWaitingTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            generateRandomWaitingTime();
        } 
    }

    void generateRandomWaitingTime()
    {
        float generatedWaitingTime = Random.Range(5.0f, 7.0f);
        this.waitingTime = generatedWaitingTime;
        skullOne.setWaitingTime(generatedWaitingTime);
        skullTwo.setWaitingTime(generatedWaitingTime);
    }
}
