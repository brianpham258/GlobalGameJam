using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public float eyeSight;
    public float stoppingDistance;

    private bool movingRight = true;

    public Transform groundDetection;
    private Transform target;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, eyeSight);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if (hitInfo.collider.CompareTag("Player")) {
                //Destroy(hitInfo.collider.gameObject);
                target = GameObject.FindGameObjectWithTag("Player").transform;
                if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
                if (Vector2.Distance(transform.position, target.position) < stoppingDistance) {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * eyeSight, Color.green);
        }
    }
}
