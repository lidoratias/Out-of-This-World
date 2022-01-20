using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private Transform firstTarget;
    private Transform secondTarget;
    public Vector3 movementSpeedVector = new Vector3(2.0f, 0f, 0f);

    public Sprite[] swordsSprites;

    public float waitingTime = 1.0f;
    private float timer = 0;

    private bool finishedFirstRotation = false;
    private bool finishedFirstMovement = false;
    private bool finishedSecondRotation = false;
    private bool finishedSecondMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        firstTarget = GameObject.FindGameObjectsWithTag("Swords Target")[0].transform;
        secondTarget = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        gameObject.GetComponent<SpriteRenderer>().sprite = swordsSprites[Random.Range(0, swordsSprites.Length - 1)];

        waitingTime = 1 + Random.Range(0.0f, 1.0f);
    }

    void Update()
    {
        if (finishedFirstRotation == false)
        {
            timer += Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 200, 60) - 30);
            if (timer >= waitingTime)
            {
                finishedFirstRotation = true;
                timer = 0;
                waitingTime = Random.Range(0.5f, 0.7f);
            }
        }

        if (finishedFirstRotation == true && finishedFirstMovement == false)
        {
            timer += Time.deltaTime;
            transform.position -= movementSpeedVector * Time.deltaTime;
            if (timer >= waitingTime)
            {
                finishedFirstMovement = true;
                timer = 0;
            }
        }
    }
}
