using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Enemy : MonoBehaviour
{
    public int health = 100;
    public List<GameObject> listNodes;
    public List<GameObject> Nodes = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < listNodes.Count; i++)
        {
            Nodes.Add(listNodes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {
        if(true)
        {
            // switch node when passing maybe?
            Vector2 direction = Nodes[0].transform.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // subtract 90 bc its facing up instead of right on X axis
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
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
