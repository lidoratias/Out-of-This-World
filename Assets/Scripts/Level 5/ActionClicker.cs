using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionClicker : HittingEnemy
{
    private GameObject target;
    public GameObject explosionEffect;

    public string targetTag;
    private float moveSpeed = 2.2f;
    private float rotateSpeed = 1f;
    private float exitMoveSpeed = 8f;

    private float timer = 0;
    public float followTimeLimit = 5.0f;

    override protected void Start()
    {
        target = GameObject.FindWithTag(targetTag);
    }

    // Update is called once per frame
    override protected void Update()
    {

        timer += Time.deltaTime;
        if (timer <= followTimeLimit)
        {
            transform.position = Vector2.MoveTowards(this.transform.localPosition,
                target.transform.localPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -2f);

            RotateTowards.rotateTowards(transform, target.transform, rotateSpeed);
        }
        else
        {
            transform.position += transform.up * Time.deltaTime * exitMoveSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == targetTag)
        {
            GameObject explosionInstance = Instantiate(explosionEffect, transform.position,
                new Quaternion(0, 0, 0, 1));
            explosionInstance.transform.localScale = new Vector3(0.14f, 0.14f, 0.14f);
            Destroy(gameObject);
        }
    }
}
