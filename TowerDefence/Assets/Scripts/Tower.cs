using UnityEngine;

public class Tower : MonoBehaviour
{
    // sets the range of the child gameobject that checks 
    public float range;
    public int damage = 10;
    public GameObject GoldManagment;
    public int goldPerEnemy = 10;
    bool ActiveState = false;
    
    private goldManager gManager;
    public Camera cam;

    public GameObject upgradeVisuals;


    void Start()
    {
        upgradeVisuals.SetActive(ActiveState);

        gManager = GoldManagment.GetComponent<goldManager>(); 
        // could be box or circle collider
        GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy.dealDamage(damage) == 0)
            {
                gManager.addGold(goldPerEnemy);
            }
        }
    }
    public void OnClick()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        LayerMask layerMask = LayerMask.GetMask("Tower");

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMask);

        if (hit)
        {   
            if(ActiveState)
            {
                ActiveState = false;
            }
            else
            {
                ActiveState = true;
            }
            upgradeVisuals.SetActive(ActiveState);
        }
    }
}
