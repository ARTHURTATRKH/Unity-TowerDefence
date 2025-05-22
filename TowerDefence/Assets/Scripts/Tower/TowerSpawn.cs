using UnityEngine;
using System.Collections.Generic;
public class TowerSpawn : MonoBehaviour
{
    public GameObject towerVisuals;
    public GameObject archerTower;
    public GameObject WizardTower;

    public Camera cam;
    private bool ActiveState = false;
    private static List<TowerSpawn> allTowerVisuals = new List<TowerSpawn>();

    void Start()
    {
        towerVisuals.SetActive(ActiveState);
        allTowerVisuals.Add(this);
    }
    void OnDestroy()
    {
        allTowerVisuals.Remove(this);
    }
    private void deactivateAllTowerVisuals()
    {
        foreach (var tower in allTowerVisuals)
        {
            tower.ActiveState = false;
            tower.towerVisuals.SetActive(false);
        }
    }
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

        LayerMask layerMaskButton = LayerMask.GetMask("TowerButton");

        RaycastHit2D hitTowerSpawner = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMask);

        RaycastHit2D hitTowerButton = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerMaskButton);

        if (hitTowerSpawner)
        {
            GameObject hitObject = hitTowerSpawner.collider.gameObject;


            if (towerVisuals.transform == hitObject.transform.GetChild(0))
            {
                bool isAlreadyActive = ActiveState;

                deactivateAllTowerVisuals();

                if (!isAlreadyActive)
                {
                    ActiveState = true;
                    towerVisuals.SetActive(ActiveState);
                }
            }
        }
        else if (hitTowerButton)
        {
            if (hitTowerButton.collider.transform.IsChildOf(this.transform))
            {
                if (hitTowerButton.collider.gameObject.name == "ArcherTower")
                {
                    transform.gameObject.SetActive(false);

                    Instantiate(archerTower, transform.position, transform.rotation, null);
                }
                else if (hitTowerButton.collider.gameObject.name == "WizardTower")
                {
                    transform.gameObject.SetActive(false);

                    Instantiate(WizardTower, transform.position, transform.rotation, null);
                }
            }
        }
        else
        {
            deactivateAllTowerVisuals();
        }
    }
}
