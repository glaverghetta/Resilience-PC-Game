using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This class implements the pause menu functionality. */
public class PauseGame : MonoBehaviour
{
    public GameObject pauseUI;                  // UI that appears when the game is paused

    public static bool canGameBePaused = true;  // is the game in a state where pausing is feasible right now?
    public static bool isGamePaused = false;    // is the game currently paused?

    /*public delegate void PauseGameDelegate();
    public event PauseGameDelegate pauseGameEvent;    // Event called when the player pauses the game

    public delegate void UnpauseGameDelegate();
    public event UnpauseGameDelegate unpauseGameEvent;    // Event called when the player unpauses the game
*/

    void Start()
    {
        /*if (FindObjectOfType<QuestionsInLevel>() != null)
        {
            //FindObjectOfType<QuestionsInLevel>().showQuestionEvent += EnablePausing;
            //FindObjectOfType<QuestionsInLevel>().movingPlayerEvent += DisablePausing;
            //FindObjectOfType<QuestionsInLevel>().finishedMovingEvent += EnablePausing;
        }

        if (FindObjectOfType<PlayerCollision>() != null)
        {
            //FindObjectOfType<PlayerCollision>().playerCollisionEvent += DisablePausing;
        }

        if (FindObjectOfType<GameManager>() != null)
        {
            //FindObjectOfType<GameManager>().restartLevelEvent += EnablePausing;
        }*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canGameBePaused)
        {
            if (isGamePaused)
            {
                unpause();
            }
            else
            {
                pause();
            }
        }
    }

    void EnablePausing()
    {
        canGameBePaused = true;
    }

    void DisablePausing()
    {
        canGameBePaused = false;
    }

    /* This function is used when the player clicks the main menu button in the pause menu */
    public void backToMainMenu()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        GameObject.FindObjectOfType<GameManager>().LoadSceneByName("Start");
    }

    /* Pause the game, stop the player's movement, and display the pause menu */
    public void pause()
    {
        isGamePaused = true;
        pauseUI.SetActive(true);
       /* if (pauseGameEvent != null)
        {
            //pauseGameEvent();
        }*/
        Time.timeScale = 0;                 // Unity time scale: https://docs.unity3d.com/ScriptReference/Time-timeScale.html
    }

    /* Unpause the game */
    public void unpause()
    {
        isGamePaused = false;
        pauseUI.SetActive(false);
     /*   if(unpauseGameEvent != null)
        {
            //unpauseGameEvent();
        }*/
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        GameObject.FindObjectOfType<GameManager>().QuitGame();
    }
}