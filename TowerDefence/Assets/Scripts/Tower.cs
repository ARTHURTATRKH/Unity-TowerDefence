using UnityEngine;

public class Tower : MonoBehaviour
{
    // sets the range of the child gameobject that checks 
    public double range;
    public int damage = 10;
    public float gold;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                if(enemy.dealDamage(damage) == 0)
                {
                    gold +=20;
                }
            }
        }
    }
}
