using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    
    public void NextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Star Rating");
    }
}
