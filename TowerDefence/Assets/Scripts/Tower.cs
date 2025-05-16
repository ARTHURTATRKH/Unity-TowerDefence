using UnityEngine;

public class Tower : MonoBehaviour
{
    // sets the range of the child gameobject that checks 
    public float range;
    public int damage = 100;
    public GameObject GoldManagment;
    public int goldPerEnemy = 10;
    bool ActiveState = false;
    public static Collider2D otherEnemy;
    
    private goldManager gManager;
    private Camera cam;

    public GameObject upgradeVisuals;


    void Start()
    {
        GoldManagment = GameObject.FindWithTag("GoldManager");
        cam = Camera.main;
        gManager = GoldManagment.GetComponent<goldManager>(); 
        upgradeVisuals.SetActive(ActiveState);
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
            otherEnemy = other;
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
            GameObject hitObject = hit.collider.gameObject;

            if (upgradeVisuals.transform == hitObject.transform.GetChild(0))
            {
                if (!ActiveState)
                {
                    ActiveState = true;
                }
                else
                {
                    ActiveState = false;
                }
                upgradeVisuals.SetActive(ActiveState);
            }
        }
    }
}
