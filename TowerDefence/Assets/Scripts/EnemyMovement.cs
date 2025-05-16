using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private LevelManagers levelManager;

    public static int totalHealth = 5;
    public TextMeshProUGUI HealthText;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        HealthText.text = "" + totalHealth;   

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
                loseHealth();
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
    public void loseHealth()
    {
        totalHealth -= 1;
        HealthText.text = "" + totalHealth;   
    }
}
