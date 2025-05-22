using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb1;

    [SerializeField] private float moveSpeed = 2f;

    //[SerializeField] private LevelManagers levelManager;
    public int EnemyHealth;
    public static int totalHealth = 5;
    private TextMeshProUGUI HealthText;

    private Transform target1;
    private int pathIndex1 = 0;

    private void Start()
    {
        GameObject HealthTextGameObject = GameObject.Find("HealthCount");
        HealthText = HealthTextGameObject.GetComponent<TextMeshProUGUI>();
        HealthText.text = "" + totalHealth;

        //levelManager = GetComponent<LevelManagers>();

        target1 = LevelManagers.main.path1[pathIndex1];
    }

    private void Update()
    {
        if (Vector2.Distance(target1.position, transform.position) <= 0.1)
        {
            pathIndex1++;

            if (pathIndex1 >= LevelManagers.main.path1.Length)
            {
                loseHealth();
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target1 = LevelManagers.main.path1[pathIndex1];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction1 = (target1.position - transform.position).normalized;

        rb1.linearVelocity = direction1 * moveSpeed;
    }
    public Transform getTarget1()
    {
        return target1;
    }

    public void loseHealth()
    {
        totalHealth -= 1;
        HealthText.text = "" + totalHealth;
    }
    public int dealDamage(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
            return 0;
        }
        else
        {
            return 1;
        }
    }

}
