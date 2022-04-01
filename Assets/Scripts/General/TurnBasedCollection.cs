using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCollection : MonoBehaviour, Observer
{

    public OperatableObject[] operatableGameObjects;

    protected List<int> order = new List<int>();
    protected int currentOrderIdx = 0;

    protected float turnsTimer;
    public float waitingTimeBetweenTurns;

    protected bool alreadyCalled = false;

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
            int generatedIdx = numsForOrder[Random.Range(0, numsForOrder.Count)];
            order.Add(generatedIdx);
            numsForOrder.Remove(generatedIdx);
        }

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (turnsTimer < waitingTimeBetweenTurns)
        {
            turnsTimer += Time.deltaTime;
        }
        else if (!alreadyCalled)
        {
            //In Turn
            operatableGameObjects[order[currentOrderIdx]].Operate();
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
