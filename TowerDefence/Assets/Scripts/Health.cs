using UnityEngine;
using TMPro;
public class Health : MonoBehaviour
{
    public int totalHealth = 5;
    public TextMeshProUGUI  t;
    private void OnTriggerEnter2D(Collider2D other)
    {

        totalHealth -= 1;
        t.text = "" + totalHealth;   
    }
   
}
