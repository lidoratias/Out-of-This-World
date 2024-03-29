using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : LinearBullet
{

    public Sprite[] sprites;
    public Sprite[] splitSprites;
    public GameObject[] splashes;
    private int dropIdx;

    public LinearBullet splitPrefab;
    public HittingEnemy sinusSplitPrefab;

    protected override void Start()
    {
        string[] targets = { "Player" };
        setTargets(targets);
        dropIdx = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[dropIdx];
    }

    // Update is called once per frame
    protected override void Update()
    {
        checkLocation();
    }

    void checkLocation()
    {
        if (transform.position.y < -4.19f)
        {
            Instantiate(splashes[dropIdx], transform.position, transform.rotation);
            Vector2[] movements;
            LinearBullet curSplit = null;
            switch (dropIdx)
            {
                case 0:
                    movements = splitsMovementsByNumOfSplits(3, -1, 1);
                    for (int i = 0; i < 3; i++)
                    {
                        curSplit = Instantiate(splitPrefab,
                                                transform.position, transform.rotation);
                        curSplit.setDirection(movements[i]);
                        curSplit.setSpeed(5);
                        curSplit.setSprite(splitSprites[dropIdx]);
                    }
                    break;

                case 1:
                    movements = splitsMovementsByNumOfSplits(4, -1.5f, 1.5f);
                    for (int i = 0; i < 4; i++)
                    {
                        curSplit = Instantiate(splitPrefab,
                            transform.position, transform.rotation);
                        curSplit.setDirection(movements[i]);
                        curSplit.setSpeed(4);
                        curSplit.setSprite(splitSprites[dropIdx]);
                    }
                    break;
                case 2:
                    movements = splitsMovementsByNumOfSplits(5, -1.7f, 1.7f);
                    for (int i = 0; i < 5; i++)
                    {
                        curSplit = Instantiate(splitPrefab,
                            transform.position, transform.rotation);
                        curSplit.setDirection(movements[i]);
                        curSplit.setSpeed(3);
                        curSplit.setSprite(splitSprites[dropIdx]);
                    }
                    break;
                case 3:
                    movements = splitsMovementsByNumOfSplits(2, -1, 1);
                    for (int i = 0; i < 2; i++)
                    {
                        curSplit = Instantiate(splitPrefab,
                            transform.position, transform.rotation);
                        curSplit.setDirection(movements[i]);
                        curSplit.setSpeed(7);
                        curSplit.setSprite(splitSprites[dropIdx]);
                    }
                    break;
                case 4:
                    HittingEnemy sinusSplitInstance = Instantiate(sinusSplitPrefab,
                        transform.position, transform.rotation);
                    sinusSplitInstance.setSprite(splitSprites[dropIdx]);
                    break;
                case 5:
                    movements = splitsMovementsByNumOfSplits(6, -1.4f, 1.4f);
                    for (int i = 0; i < 6; i++)
                    {
                        curSplit = Instantiate(splitPrefab,
                        transform.position, transform.rotation);
                        curSplit.setDirection(movements[i]);
                        curSplit.setSpeed(i + 1);
                        curSplit.setSprite(splitSprites[dropIdx]);
                    }
                    break;
                case 6:
                    movements = splitsMovementsByNumOfSplits(7, -1.8f, 1.8f);
                    for (int i = 0; i < 7; i++)
                    {
                        curSplit = Instantiate(splitPrefab,
                            transform.position, transform.rotation);
                        curSplit.setDirection(movements[i]);
                        curSplit.setSprite(splitSprites[dropIdx]);
                        if (i <= 3)
                        {
                            curSplit.setSpeed((i + 1) * 1.5f);
                        } else
                        {
                            curSplit.setSpeed((7 - i) * 1.5f);
                        }
                    }
                    break;
            }
            Destroy(gameObject);
        }
    }

    Vector2[] splitsMovementsByNumOfSplits(int numOfSplits, float minVal, float maxVal)
    {
        Vector2[] movements = new Vector2[numOfSplits];
        float spaceBetweenSplits = (maxVal - minVal) / (numOfSplits - 1);
        for (int i = 0; i < numOfSplits; i++)
        {
            movements[i] = new Vector2(minVal + (spaceBetweenSplits * i), 1);
        }

        return movements;
    }

    public void setDropIdx(int idx)
    {
        this.dropIdx = idx;
    }
}
