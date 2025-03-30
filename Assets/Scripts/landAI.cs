using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float chaseSpeed = 3.5f;
    public float detectionRange = 5f;
    public Transform player;

    private Vector2 targetPosition;
    private Rigidbody2D rb;
    private bool isChasing = false;

    [SerializeField] private bool isBoss = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = pointA.position;
    }

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed;

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f)
        {
            targetPosition = (Vector2)targetPosition == (Vector2)pointA.position ? pointB.position : pointA.position;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;
        if (isBoss)
        {
            rb.velocity = new Vector2(rb.velocity.x, 16f);
        }
    }
}
