using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject archerTower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(archerTower, this.transform.parent.parent);
    }
    // could make it a button or use raycast 
    void OnButtonPress()
    {

    }
}
