using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public PlayerLinearBullet bulletPrefab;

    public float timer = 0f;
    public double waitingTime = 0.2;

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > waitingTime)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        PlayerLinearBullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        string[] bulletTargets = { "Player"};
        bullet.setTargets(bulletTargets);
    }
}
