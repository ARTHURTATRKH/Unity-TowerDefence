using UnityEngine;

public class Tower : MonoBehaviour
{
    // sets the range of the child gameobject that checks 
    public float range;
    public int damage = 10;
    public GameObject GoldManagment;
    public int goldPerEnemy = 10;
    private goldManager gManager;
    

    void Start()
    {
        gManager = GoldManagment.GetComponent<goldManager>(); 
        // could be box or circle collider
        GetComponent<CircleCollider2D>().radius = range;
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
                    gManager.addGold(goldPerEnemy);
                }
            }
        }
    }
    public void OnClick()
    {
        
    }
}
