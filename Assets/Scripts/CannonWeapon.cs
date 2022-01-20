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
    public float waitingTime = 4;

    void Start()
    {
        this.cannonString.PlayAnimation(waitingTime);
        this.cannonFire.PlayAnimation(waitingTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= waitingTime)
        {
            if (waitingTime == 4)
                waitingTime = 5;
            else
                waitingTime = 4;
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        this.cannonString.PlayAnimation(waitingTime);
        this.cannonFire.PlayAnimation(waitingTime);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(explosionCloud, firePoint.position, new Quaternion(0, 0, 0, 1));
    }
}
