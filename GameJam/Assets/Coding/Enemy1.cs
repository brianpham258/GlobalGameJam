using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
