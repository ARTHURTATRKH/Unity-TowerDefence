using UnityEngine;
using TMPro;
public class EndZone : MonoBehaviour
{
    public int totalHealth = 5;
    public TextMeshProUGUI  t;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
        totalHealth -= 1;
        t.text = "" + totalHealth;   
        }
    }
}
