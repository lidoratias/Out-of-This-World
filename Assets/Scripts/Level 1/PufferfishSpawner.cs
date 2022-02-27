using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferfishSpawner : MonoBehaviour
{

    private Pufferfish[] pufferfishObjects = new Pufferfish[4];
    public Pufferfish pufferfishPrefab;
    private int[] colorsIdxes = { 0, 1, 2, 3 };
    
    IDictionary<int, float> yLocations = new Dictionary<int, float>();

    int[] appearanceOrder = { 0, 1, 2, 3 };
    int[] locationOrder = { 0, 1, 2, 3 };
    
    private float timer;
    private float waitingTimeBetweenSpawns = 0.5f;
    private float waitingTimeBetweenAppears = 1.0f;
    int idxToInstantiate = 0;

    // Start is called before the first frame update
    void Start()
    {
        yLocations.Add(0, -3.6f);
        yLocations.Add(1, -1.2f);
        yLocations.Add(2, 1.2f);
        yLocations.Add(3, 3.6f);

        //Fisher-Yates Shuffling for a random order of activation
        for (int i = appearanceOrder.Length - 1; i >= 1; i--)
        {
            /*int j = Random.Range(0, i);
            Pufferfish temp = pufferfishObjects[i];
            pufferfishObjects[i] = pufferfishObjects[j];
            pufferfishObjects[j] = temp;*/

            int h = Random.Range(0, i);
            int tempIdx = appearanceOrder[i];
            appearanceOrder[i] = appearanceOrder[h];
            appearanceOrder[h] = tempIdx;
            
            int k = Random.Range(0, i);
            int tempLoc = locationOrder[i];
            locationOrder[i] = locationOrder[k];
            locationOrder[k] = tempLoc;
        }

        InstantiateObjects();
        idxToInstantiate = 0;
        //ActivateObjects();
    }

    void InstantiateObjects()
    {
        Pufferfish pf = Instantiate(pufferfishPrefab, transform.position,
            transform.rotation);
        pf.setColor(colorsIdxes[appearanceOrder[idxToInstantiate]]);
        pf.setTargetYLocation(yLocations[locationOrder[idxToInstantiate]]);
        pf.setWaitingTimeY(0 + 0.5f * idxToInstantiate);
        pf.setWaitingTimeX(2.0f + (0.5f * idxToInstantiate));
        pufferfishObjects[idxToInstantiate] = pf;

        if (idxToInstantiate < pufferfishObjects.Length - 1)
        {
            idxToInstantiate++;
            InstantiateObjects();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (pufferfishObjects[0].getIsInPlace() && pufferfishObjects[1].getIsInPlace() &&
            pufferfishObjects[2].getIsInPlace() && pufferfishObjects[3].getIsInPlace())
        {
            for (int i = 0; i < pufferfishObjects.Length; i++)
            {
                pufferfishObjects[i].setIsEveryFishInPlace(true);
            }
        }
    }
}
