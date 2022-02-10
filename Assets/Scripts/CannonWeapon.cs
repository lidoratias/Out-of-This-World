using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject explosionCloud;
    public CannonString cannonString;
    public CannonFire cannonFire;

    public float timer = 0f;
    public float waitingTime = 0.5f;

    void Start()
    {
        this.cannonString.setSpeed(waitingTime);
        this.cannonFire.setSpeed(waitingTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= waitingTime)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(explosionCloud, firePoint.position, new Quaternion(0, 0, 0, 1));
    }
}
