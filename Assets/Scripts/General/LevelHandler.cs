using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    private int score;
    private int phase = 1;
    public Enemy enemy;

    public ActivatedGameObjectsHolder[] phasesList;
    public int[] enemyHealthsList;

    public float[] waitingTimesBetweenPhases;
    private float timer = 0;
    private bool isBetweenPhases = false;

    void Start()
    {
        enemy.setPhase(this.phase);
        enemy.setHealth(enemyHealthsList[0]);
        ActivatedGameObject[] currentPhaseObjects = phasesList[0].getObjectsArray();

        for (int i = 0; i < currentPhaseObjects.Length; i++)
        {
            currentPhaseObjects[i].SetActive(true);
        }

        for (int i = 1; i < phasesList.Length; i++)
        {
            currentPhaseObjects = phasesList[i].getObjectsArray();
            for (int j = 0; j < currentPhaseObjects.Length; j++)
            {
                currentPhaseObjects[j].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBetweenPhases)
        {
            timer += Time.deltaTime;
        }

        if (enemy.getHealth() <= 20)
        {
            if (phase == phasesList.Length)
            {
                Debug.Log("You Win!");
            }
            else
            {
                isBetweenPhases = true;
                phase++;
                enemy.setPhase(phase);
                enemy.setHealth(enemyHealthsList[phase - 1]);

                ActivatedGameObject[] currentPhaseObjects = phasesList[phase - 2].getObjectsArray();
                for (int i = 0; i < currentPhaseObjects.Length; i++)
                {
                    currentPhaseObjects[i].phaseOut();
                }
            }
        }

        if (phase > 1 && timer >= waitingTimesBetweenPhases[phase - 2])
        {
            ActivatedGameObject[] currentPhaseObjects =
                phasesList[phase - 1].getObjectsArray();
            for (int i = 0; i < currentPhaseObjects.Length; i++)
            {
                currentPhaseObjects[i].phaseIn();
            }
        }
    }

    public int getPhase()
    {
        return this.phase;
    }
}
