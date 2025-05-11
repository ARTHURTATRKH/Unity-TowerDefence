using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    // Loads new Scene using SceneManager
    private string newScene = "Main";
    public void play()
    {
        SceneManager.LoadScene(newScene);
    }
}
