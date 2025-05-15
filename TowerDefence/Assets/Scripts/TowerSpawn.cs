using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    //public GameObject archerTower;
    //public GameObject wizardTower;
    public GameObject towerVisuals;
    public Camera cam;
    private bool ActiveState = false;


    void Start()
    {
        towerVisuals.SetActive(ActiveState);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Onclick();
        }
    }

    public void Onclick()
    {
        
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        LayerMask layerMask = LayerMask.GetMask("Tower");

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMask);

        if(hit)
        {   
            if(ActiveState)
            {
                ActiveState = false;
            }
            else
            {
                ActiveState = true;
            }
            towerVisuals.SetActive(ActiveState);
        }
    }
}
