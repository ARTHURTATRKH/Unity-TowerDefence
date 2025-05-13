using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
