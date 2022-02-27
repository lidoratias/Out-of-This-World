using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Sprite[] swordsSprites;
    public Rigidbody2D rb;
    private float timer = 0;
    private float waitingTime = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite =
            swordsSprites[Random.Range(0, swordsSprites.Length - 1)];
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        rb.gravityScale = 1.2f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= waitingTime)
        {
            rb.gravityScale += 0.000005f;
            timer = 0;
        }
    }
}
