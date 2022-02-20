using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    private int score;
    private int phase = 1;
    public Enemy enemy;

    public ActivatedGameObject[] phaseOneObjects;
    public ActivatedGameObject[] phaseTwoObjects;
    public ActivatedGameObject[] phaseThreeObjects;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < phaseOneObjects.Length; i++)
        {
            phaseOneObjects[i].SetActive(true);
        }

        for (int i = 0; i < phaseTwoObjects.Length; i++)
        {
            phaseTwoObjects[i].SetActive(false);
        }

        for (int i = 0; i < phaseThreeObjects.Length; i++)
        {
            phaseThreeObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.getHealth() <= 20 && phase == 1)
        {
            enemy.setHealth(1500);
            phase = 2;

            for (int i = 0; i < phaseOneObjects.Length; i++)
            {
                phaseOneObjects[i].phaseOut();
            }

            for (int i = 0; i < phaseTwoObjects.Length; i++)
            {
                phaseTwoObjects[i].phaseIn();
            }

        }

        if (enemy.getHealth() <= 20 && phase == 2)
        {
            enemy.setHealth(1500);
            phase = 3;

            for (int i = 0; i < phaseTwoObjects.Length; i++)
            {
                phaseTwoObjects[i].phaseOut();
            }

            for (int i = 0; i < phaseThreeObjects.Length; i++)
            {
                phaseThreeObjects[i].phaseIn();
            }

        }
    }
}
