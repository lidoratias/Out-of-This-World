using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingLineOfStars : MonoBehaviour
{
    public Vector3 startingPos;
    public GameObject starPrefab;

    public GameObject[] instantiatedObjects;
    private int idx = 0;

    public char spawnAxis;
    
    public Vector2 movement;
    
    public int numOfObjects;
    public float spaceBetweenSpawns;
    public int numOfEmptyIndexes;
    // Start is called before the first frame update
    void Start()
    {
        instantiatedObjects = new GameObject[numOfObjects];

        Vector3 currentPos = startingPos;
        float[] emptyIndexes = new float[numOfEmptyIndexes];
        emptyIndexes[0] = Random.Range(0, numOfObjects - numOfEmptyIndexes);
        for (int i = 1; i < emptyIndexes.Length; i++)
        {
            emptyIndexes[i] = emptyIndexes[0] + i;
        }

        for (int i = 0; i < numOfObjects; i++)
        {
            if (System.Array.IndexOf(emptyIndexes, i) == -1)
            {
                InstantiateObject(currentPos);
            }

            if (spawnAxis == 'x' || spawnAxis == 'X')
            {
                currentPos = new Vector3(currentPos.x + spaceBetweenSpawns, currentPos.y, currentPos.z);
            } else if (spawnAxis == 'y' || spawnAxis == 'Y')
            {
                currentPos = new Vector3(currentPos.x, currentPos.y + spaceBetweenSpawns, currentPos.z);
            }
        }
    }

    void InstantiateObject(Vector3 currentPos)
    {
        GameObject star = Instantiate(starPrefab, currentPos, transform.rotation);
        LinearMovement linearMovement = star.AddComponent<LinearMovement>() as LinearMovement;
        linearMovement.setSpeed(4);
        linearMovement.setMovement(movement);
        
        if (movement.x != 0)
        {
            linearMovement.setMaxXValue(1000);
            linearMovement.setMinXValue(-1000);
        } else if (movement.y != 0)
        {
            linearMovement.setMaxYValue(1000);
            linearMovement.setMinYValue(-1000);
        }
        star.transform.SetParent(gameObject.transform);
        instantiatedObjects[idx] = star;
        idx++;
    }
}
