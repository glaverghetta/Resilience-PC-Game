using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    bool hasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public GameObject answerQuestionUI;
    public Rigidbody player;

    public delegate void GameOverDelegate();
    public event GameOverDelegate gameOverEvent;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true); //enables the level completion ui
    }

    public void GameOver()
    {
        if (!hasEnded)
        {
            hasEnded = true;

            if(gameOverEvent != null)
            {
                gameOverEvent();
            }

            Invoke("Restart", restartDelay);
        }
    }

    public void CanGameOverAgain()
    {
        hasEnded = false;
        player.useGravity = true;
    }

    void Restart()
    {
        answerQuestionUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}