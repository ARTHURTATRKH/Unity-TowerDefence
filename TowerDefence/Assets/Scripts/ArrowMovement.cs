using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    public int damage;
    public GameObject GoldManagment;
    private goldManager gManager;
    public int goldPerEnemy = 10;
    public int speed; 
    void Start()
    {
        GoldManagment = GameObject.FindWithTag("GoldManager");
        gManager = GoldManagment.GetComponent<goldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy.dealDamage(damage) == 0)
            {
                gManager.addGold(goldPerEnemy);
            }
        }
    }

    public void move()
    {
        Vector3 direction = (Tower.otherEnemy.transform.position - transform.position).normalized;
        transform.Translate(direction  * Time.deltaTime);
    }
}
