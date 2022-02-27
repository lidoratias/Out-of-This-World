using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : ActivatedGameObject
{
    public float waitingTime;
    private float timer;
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            timer = 0;
            Vector3 instancePos = new Vector3(transform.position.x,
                Random.Range(1.5f, -3.7f), transform.position.z);
            Instantiate(ghost, instancePos, new Quaternion(0, 0, 0, 1));
            waitingTime = Random.Range(4.0f, 6.0f);
        }
    }

    public override void phaseIn()
    {
        gameObject.SetActive(true);
    }

    public override void phaseOut()
    {
        gameObject.SetActive(false);
    }
}
