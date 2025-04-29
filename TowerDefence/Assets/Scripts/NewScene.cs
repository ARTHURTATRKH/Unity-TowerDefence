using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Main");
    }
}
