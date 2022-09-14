using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DustInstantiator : MonoBehaviour
{

    public float timer = 0f;
    public float waitingTime = 0.3f;
    public GameObject dust;
    public float size;
    private float lastParentX = -1000;
    private bool toReflect = false;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateDust();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent.position.x > lastParentX)
        {
            toReflect = false;
        }
        else
        {
            toReflect = true;
        }
            timer = timer + Time.deltaTime;
        if (timer >= waitingTime)
        {
            InstantiateDust();
            timer = 0f;
        }
        lastParentX = this.transform.parent.position.x;
    }

    void InstantiateDust()
    {
        GameObject newDust = Instantiate(this.dust, transform.parent.position, 
                Quaternion.Euler(0, 0, 0)) as GameObject;  // instatiate the object
        if (toReflect)
        {
            newDust.transform.localScale = new Vector3(-size, size, size);
        }
        else
        {
            newDust.transform.localScale = new Vector3(size, size, size);
        }
        newDust.transform.position = new Vector3(newDust.transform.position.x,
             newDust.transform.position.y - 0.6f, newDust.transform.position.z);
    }
}