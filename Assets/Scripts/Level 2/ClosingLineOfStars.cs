using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingLineOfStars : MonoBehaviour
{
    public Vector3 startingPos;
    public GameObject starPrefab;

    private GameObject[] instantiatedObjects;
    private int idx = 0;

    public char spawnAxis;

    public Vector2 movement;

    public int numOfEmptyIndexes;
    public int numOfEffectedIndexes;
    public int numOfObjects;

    public float spaceBetweenSpawns;
    public float speed;
    private float timer;
    private float waitingTime;

    private int[] effectedIndexes;
    public string[] effects;
    public Sprite[] effectsSprites;
    public Sprite regularSprite;

    private bool isEffected = false;

    // Start is called before the first frame update
    void Start()
    {
        waitingTime = Random.Range(1.3f, 1.8f);

        effectedIndexes = new int[numOfEffectedIndexes];
        instantiatedObjects = new GameObject[numOfObjects];

        Vector3 currentPos = startingPos;
        int[] emptyIndexes = new int[numOfEmptyIndexes];
        emptyIndexes[0] = Random.Range(0, numOfObjects - numOfEmptyIndexes);
        for (int i = 1; i < emptyIndexes.Length; i++)
        {
            emptyIndexes[i] = emptyIndexes[0] + i;
        }

        List<int> legalIdxesForEffectObjects = new List<int>();

        for (int i = 0; i < numOfObjects; i++)
        {
            if (System.Array.IndexOf(emptyIndexes, i) == -1)
            {
                legalIdxesForEffectObjects.Add(i);
            }
        }

        for (int i = 0; i < numOfEffectedIndexes; i++)
        {
            int curIdx = legalIdxesForEffectObjects[Random.Range(0, legalIdxesForEffectObjects.Count)];
            legalIdxesForEffectObjects.Remove(curIdx);
            effectedIndexes[i] = curIdx;
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
            idx++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime && !isEffected)
        {
            for (int i = 0; i < effectedIndexes.Length; i++)
            {
                Star star = instantiatedObjects[effectedIndexes[i]].GetComponent<Star>();
                (instantiatedObjects[effectedIndexes[i]].GetComponent(star.getEffect()) as MonoBehaviour).enabled = true;
            }
            timer = 0;
            isEffected = true;
        }
    }

    void InstantiateObject(Vector3 currentPos)
    {
        GameObject newObject = Instantiate(starPrefab, currentPos, transform.rotation);
        newObject.GetComponent<SpriteRenderer>().sprite = regularSprite;
        LinearMovement linearMovement = newObject.AddComponent<LinearMovement>() as LinearMovement;
        linearMovement.setSpeed(speed);
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
        newObject.transform.SetParent(gameObject.transform);

        if (System.Array.IndexOf(effectedIndexes, idx) > -1)
        {
            Star star = newObject.GetComponent<Star>();
            int effectIdx = Random.Range(0, effects.Length);
            
            if (effects[effectIdx] == "burst")
            {
                star.setEffect("BurstEffect");
                newObject.AddComponent<BurstEffect>();
            }
            else if (effects[effectIdx] == "split")
            {
                SplitEffect se = newObject.AddComponent<SplitEffect>();
                Vector2[] movements = { new Vector2(0, 1), new Vector2(0, -1) };
                float[] speeds = { 7.0f, 7.0f };
                se.setMovements(movements);
                se.setSpeeds(speeds);
                GameObject splitPrefab = starPrefab;
                se.setSprite(effectsSprites[effectIdx]);
                se.setPrefab(splitPrefab);
                se.setSourceObject(newObject);
                star.setEffect("SplitEffect");
            }
            newObject.GetComponent<SpriteRenderer>().sprite
                = effectsSprites[effectIdx];
        }

        instantiatedObjects[idx] = newObject;
    }
}
