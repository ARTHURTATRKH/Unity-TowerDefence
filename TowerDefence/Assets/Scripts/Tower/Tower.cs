using UnityEngine;

public class Tower : MonoBehaviour
{
    // sets the range of the child gameobject that checks 
    public float range;
    public float fireRate;
    private float fireCooldown = 0f;
    public GameObject GoldManagment;
    public GameObject projectile;
    public GameObject upgradeVisuals;
    private bool enemyInRange = false;

    bool ActiveState = false;
    public static GameObject otherEnemy;
    
    private goldManager gManager;
    private Camera cam;




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
        if (enemyInRange && otherEnemy != null)
        {
            fireCooldown -= Time.deltaTime;

            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = fireRate;
            }
        }
    }
    private void Shoot()
    {
        if (otherEnemy != null)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            otherEnemy = other.gameObject;
            enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == otherEnemy)
        {
            enemyInRange = false;
            otherEnemy = null;
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
