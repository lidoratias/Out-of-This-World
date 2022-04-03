using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEffect : Effect
{
    public GameObject splitPrefab;
    public GameObject source;
    public Sprite sprite;

    public Vector2[] movements;
    public float[] speeds;
    
    //private List<GameObject> splits = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        this.enabled = false;
    }

    void OnEnable()
    {
        for (int i = 0; i < movements.Length; i++)
        {
            GameObject curSplit = Instantiate(splitPrefab,
                source.transform.position, transform.rotation);
            curSplit.GetComponent<SpriteRenderer>().sprite = sprite;
            if (movements[i].x != 0 || movements[i].y != 0)
            {
                LinearMovement lm = curSplit.AddComponent<LinearMovement>() as LinearMovement;
                lm.setMovement(movements[i]);
                lm.setSpeed(speeds[i]);
                if (movements[i].x != 0)
                {
                    lm.setMinXValue(-1000);
                    lm.setMaxXValue(1000);
                }
                else
                {
                    lm.setMinYValue(-1000);
                    lm.setMaxYValue(1000);
                }
            }
            //splits.Add(curSplit);
        }
        Destroy(source);
    }

    public void setMovements(Vector2[] movements)
    {
        this.movements = movements;
    }

    public void setSpeeds(float[] speeds)
    {
        this.speeds = speeds;
    }

    public void setPrefab(GameObject splitPrefab) {
        this.splitPrefab = splitPrefab;
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public void setSourceObject(GameObject source)
    {
        this.source = source;
    }
}
