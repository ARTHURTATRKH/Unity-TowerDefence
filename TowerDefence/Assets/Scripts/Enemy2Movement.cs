using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2;

    [SerializeField] private float moveSpeed2 = 2f;

    //[SerializeField] private LevelManagers levelManager;

    //public static int totalHealth = 5;
    //public TextMeshProUGUI HealthText;

    private Transform target2;
    private int pathIndex2 = 0;

    private void Start()
    {
        //HealthText.text = "" + totalHealth;   

        //levelManager = GetComponent<LevelManagers>();

        target2 = LevelManagers.main.path2[pathIndex2];
    }

    private void Update()
    {
        if (Vector2.Distance(target2.position, transform.position) <= 0.1)
        {
            pathIndex2++;

            if (pathIndex2 >= LevelManagers.main.path2.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target2 = LevelManagers.main.path2[pathIndex2];
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction2 = (target2.position - transform.position).normalized;

        rb2.linearVelocity = direction2 * moveSpeed2;
    }   
    public Transform getTarget2()
    {
        return target2;
    }

    /*
    public void loseHealth()
    {
        totalHealth -= 1;
        HealthText.text = "" + totalHealth;   
    }
    */

}