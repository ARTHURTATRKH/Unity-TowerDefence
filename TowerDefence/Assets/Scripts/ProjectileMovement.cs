using UnityEngine;

public class ProjectileMovement : MonoBehaviour
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
        angle();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyMovement>() != null)
            {
                EnemyMovement enemy = other.GetComponent<EnemyMovement>();
                if (enemy.dealDamage(damage) == 0)
                {
                    gManager.addGold(goldPerEnemy);
                }
            }
            else
            {
                Enemy2Movement enemy2 = other.GetComponent<Enemy2Movement>();
                if (enemy2.dealDamage(damage) == 0)
                {
                    gManager.addGold(goldPerEnemy);
                }
            }
            Destroy(gameObject);
        }
    }

    public void move()
    {
        if (Tower.otherEnemy != null)
        {
            Vector3 direction = (Tower.otherEnemy.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    public void angle()
    {
        if (Tower.otherEnemy != null)
        {
            Vector2 direction = Tower.otherEnemy.transform.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
}
