using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : MonoBehaviour
{
    public Transform firePoint;
    public CannonDirectedBullet bulletPrefab;

    public GameObject explosionCloud;
    public Vector3 explosionSize;

    public CannonString cannonString;
    public CannonFire cannonFire;

    public float timer = 0f;
    public float waitingTime = 0.5f;
    private bool isPhasingOut = false;

    public GameObject eye;
    private Animator eyeAnimator;
    public string eyeBlinkAnimName;

    void Start()
    {
        this.cannonString.setSpeed(waitingTime);
        this.cannonFire.setSpeed(waitingTime);

        eyeAnimator = eye.GetComponent<Animator>();
    }

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
        CannonDirectedBullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        string[] bulletTargets = { "Player" };
        bullet.setTargets(bulletTargets);
        GameObject explosionCloudInstance = Instantiate(explosionCloud, firePoint.position, new Quaternion(0, 0, 0, 1));
        explosionCloudInstance.transform.localScale = explosionSize;

        eyeAnimator.Play(eyeBlinkAnimName);
    }

    public void phaseOut()
    {
        this.isPhasingOut = true;
    }
}
