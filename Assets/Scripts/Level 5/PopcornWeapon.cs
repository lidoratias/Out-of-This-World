using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timer = 0f;
    public float waitingTime = 0.5f;
    private bool isPhasingOut = false;

    // Update is called once per frame
    void Update()
    {
        if (!isPhasingOut)
        {
            timer = timer + Time.deltaTime;
            if (timer >= waitingTime)
            {
                Shoot();
                timer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void phaseOut()
    {
        this.isPhasingOut = true;
    }
}