using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
