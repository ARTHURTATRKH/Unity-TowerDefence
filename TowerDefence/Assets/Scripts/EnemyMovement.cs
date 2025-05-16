using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManagers.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1)
        {
            pathIndex++;
          
            if (pathIndex >= LevelManagers.main.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManagers.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direaction = (target.position - transform.position).normalized;

        rb.linearVelocity = direaction * moveSpeed;
    }
}
