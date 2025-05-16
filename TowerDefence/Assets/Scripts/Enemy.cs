using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    public int health = 100;
    public EnemyMovement enemyMovement;
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }
    void Update()
    {
        angle();
    }
    public void angle()
    {
        Vector2 direction = enemyMovement.getTarget().transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
    public int dealDamage(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            return 0;
        }
        return 1;
    }
}
