using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public void NextLevel()
    {
        // go forward 1 scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
