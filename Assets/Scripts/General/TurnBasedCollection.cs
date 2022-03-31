using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCollection : MonoBehaviour, Observer
{

    public OperatableObject[] operatableGameObjects;

    private List<int> order = new List<int>();
    private int currentOrderIdx = 0;

    private float turnsTimer;
    public float waitingTimeBetweenTurns;

    private bool alreadyCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        List<int> numsForOrder = new List<int>();
        for (int i = 0; i < operatableGameObjects.Length; i++)
        {
            numsForOrder.Add(i);
            operatableGameObjects[i].register(this);
        }

        int maxRange = numsForOrder.Count;
        for (int i = 0; i < maxRange; i++)
        {
            order.Add(numsForOrder[Random.Range(0, numsForOrder.Count)]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (turnsTimer < waitingTimeBetweenTurns)
        {
            turnsTimer += Time.deltaTime;
        }
        else if (!alreadyCalled)
        {
            //In Turn
            operatableGameObjects[currentOrderIdx].Operate();
            alreadyCalled = true;
        }
    }

    public void updateRecieved()
    {
        currentOrderIdx++;
        if (currentOrderIdx == operatableGameObjects.Length)
        {
            currentOrderIdx = 0;
        }
        alreadyCalled = false;
        turnsTimer = 0;
    }
}
