using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    private int score;
    private int phase = 1;
    public Enemy enemy;

    public GameObject[] phaseOneObjects;
    public GameObject[] phaseTwoObjects;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.getHealth() <= 0)
        {
            enemy.setHealth(7200);

            //Enters phase 2 of the level
            for (int i = 0; i < phaseOneObjects.Length; i++)
            {
                phaseOneObjects[i].SetActive(false);
            }

            for (int i = 0; i < phaseTwoObjects.Length; i++)
            {
                phaseTwoObjects[i].SetActive(true);
            }
        }
    }
}
