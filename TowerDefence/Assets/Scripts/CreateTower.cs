using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject archerTower;

    private GameObject TowerSpawn; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TowerSpawn = transform.parent.parent.gameObject;

        TowerSpawn.SetActive(false);
        // creates itself at tower spawn, with its rotation being the same and having no parent function.
        Instantiate(archerTower, transform.parent.parent.position, transform.parent.parent.rotation, null);
    }
    // could make it a button or use raycast 
    void OnButtonPress()
    {

    }
}
