using UnityEngine;

public class WizardTower : Tower
{
    public float WizardRange;
    public int WizardDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        range = WizardRange;
        damage = WizardDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
