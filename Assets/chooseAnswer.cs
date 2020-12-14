using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseAnswer : MonoBehaviour
{
    public void goToLevel1()
    {
        // go back to previous level (scene)
       // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);

        //SceneManager.LoadScene(1);
    }

    public void goToL1WrongAnswer()
    {
        // go back to previous level (scene)
        // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(4);

        //SceneManager.LoadScene(1);
    }

    public void goToLevel2()
    {
        // go back to previous level (scene)
        // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(5);

        //SceneManager.LoadScene(1);
    }

    public void goToL2WrongAnswer()
    {
        // go back to previous level (scene)
        // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(8);

        //SceneManager.LoadScene(1);
    }

    public void goToLevel3()
    {
        // go back to previous level (scene)
        // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(9);

        //SceneManager.LoadScene(1);
    }

    public void goToL3WrongAnswer()
    {
        // go back to previous level (scene)
        // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(12);

        //SceneManager.LoadScene(1);
    }

    public void goBackTwoLevels()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex - 2);
    }

    public void beginNextLevel()
    {
        // go forward to next level (scene)
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

     
}
