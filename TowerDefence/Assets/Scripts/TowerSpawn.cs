using UnityEngine;
using System.Collections.Generic;
public class TowerSpawn : MonoBehaviour
{
    public GameObject towerVisuals;
    public Camera cam;
    private bool ActiveState = false;
    private static List<bool> checkedActiveStates = new List<bool>();



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
            GameObject hitObject = hit.collider.gameObject;
            // need to have system to set active state for all other scripts to false if a new one is clicked and if 
            // ground is clicked everything is set to false
            if (towerVisuals.transform == hitObject.transform.GetChild(0))
            {
                if (!ActiveState)
                {
                    ActiveState = true;
                    checkedActiveStates.Add(ActiveState);
                }
                else
                {
                    ActiveState = false;
                    //checkedActiveStates.remove();
                }
                towerVisuals.SetActive(ActiveState);
            }
        }
    }
}
