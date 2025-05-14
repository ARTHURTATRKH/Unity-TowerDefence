using UnityEngine;
using TMPro;
public class goldManager : MonoBehaviour
{
    public int totalGold = 0;
    public int startingGold;

    private int UpgradeCost;

    public TextMeshProUGUI  t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalGold += startingGold;
        t.text = ""+totalGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addGold(int goldAdded)
    {
        totalGold += goldAdded;
        t.text = ""+totalGold;  
    }

    public bool canBuyUpgrade()
    {
        if(totalGold >= UpgradeCost)
        {
            return true;
        }
        return false;
    }
    public void buyUpgrade()
    {
        if(canBuyUpgrade())
        {
            totalGold -= UpgradeCost;
            t.text = ""+totalGold;
        }
    }
}
