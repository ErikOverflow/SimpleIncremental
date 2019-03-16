using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadNextScene(Object scene)
    {
        SceneManager.LoadSceneAsync(scene.name);
    }
}