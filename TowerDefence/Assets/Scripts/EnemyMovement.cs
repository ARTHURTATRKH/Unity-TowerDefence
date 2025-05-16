using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private LevelManagers levelManager;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        levelManager = GetComponent<LevelManagers>();

        target = levelManager.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1)
        {
            pathIndex++;

            if (pathIndex >= levelManager.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = levelManager.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }
    public Transform getTarget()
    {
        return target;
    }
}
