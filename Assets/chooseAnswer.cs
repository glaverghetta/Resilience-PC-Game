using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseAnswer : MonoBehaviour
{
    public void previousLevel()
    {
        // go back to previous level (scene)
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex - 1);
    }

    public void beginNextLevel()
    {
        // go forward to next level (scene)
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
