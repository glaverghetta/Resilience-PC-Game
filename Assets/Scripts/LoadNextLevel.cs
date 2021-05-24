using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    
    public void NextLevel()
    {
        FindObjectOfType<GameManager>().LoadSceneByName("Star Rating");
    }
}
