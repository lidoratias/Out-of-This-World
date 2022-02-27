using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{

    public Sprite[] sprites;

    private int color;

    private Vector2 xDirection = new Vector2(1, 0);
    private Vector2 yDirection = new Vector2(0, 1);

    public int speed = -20;

    private float targetYLocation;
    private float waitingTimeX = 3.0f;
    private float timerX = 0;
    private float waitingTimeY = 3.0f;
    private float timerY = 0;

    private bool isInPlace = false;
    private bool isEveryFishInPlace = false;

    // Update is called once per frame
    void Update()
    {
        timerY += Time.deltaTime;

        if (timerY >= waitingTimeY && transform.position.y < targetYLocation)
        {
            transform.Translate(yDirection * 4 * Time.deltaTime);
            isInPlace = true;
        }

        if (isEveryFishInPlace)
        {
            timerX += Time.deltaTime;
        }

        if (timerX >= waitingTimeX)
        {
            transform.Translate(xDirection * this.speed * Time.deltaTime);
        }
    }

    public void setColor(int color)
    {
        this.color = color;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[color];
    }

    public void setTargetYLocation(float y)
    {
        targetYLocation = y;
    }

    public void setWaitingTimeX(float waitingTimeX)
    {
        this.waitingTimeX = waitingTimeX;
    }

    public void setWaitingTimeY(float waitingTimeY)
    {
        this.waitingTimeY = waitingTimeY;
    }

    public void setIsEveryFishInPlace(bool isEveryFishInPlace)
    {
        this.isEveryFishInPlace = isEveryFishInPlace;
    }

    public bool getIsInPlace()
    {
        return this.isInPlace;
    }
}
