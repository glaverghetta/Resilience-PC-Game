using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This class implements the pause menu functionality. */
public class PauseGame : MonoBehaviour
{
    public Rigidbody player;
    Vector3 savedVelocy;                        // velocty that the player had at the moment that the game is paused
    Quaternion savedRotation;                   // the player's rotation at the moment the game was paused

    bool gravityWasOn;                          // was gravity enabled when the game was paused?

    public GameObject pauseUI;                  // UI that appears when the game is paused

    public static bool canGameBePaused = true;  // is the game in a state where pausing is feasible right now?
    public static bool isGamePaused = false;    // is the game currently paused?

    void Start()
    {
        FindObjectOfType<QuestionsInLevel>().showQuestionEvent += EnablePausing;
        FindObjectOfType<QuestionsInLevel>().movingPlayerEvent += DisablePausing;
        FindObjectOfType<QuestionsInLevel>().finishedMovingEvent += EnablePausing;

        FindObjectOfType<PlayerCollision>().playerCollisionEvent += DisablePausing;

        FindObjectOfType<GameManager>().restartLevelEvent += EnablePausing;
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
        player.useGravity = true;
        isGamePaused = false;
        GameObject.FindObjectOfType<GameManager>().LoadSceneByName("Start");
    }

    /* Pause the game, stop the player's movement, and display the pause menu */
    public void pause()
    {
        isGamePaused = true;
        gravityWasOn = player.useGravity;

        player.useGravity = false;
        savedVelocy = player.velocity;
        player.velocity = Vector3.zero;
        savedRotation = player.rotation;
        player.freezeRotation = true;

        pauseUI.SetActive(true);
    }

    /* Unpause the game */
    public void unpause()
    {
        isGamePaused = false;
        if(gravityWasOn)
            player.useGravity = true;

        player.velocity = savedVelocy;
        player.freezeRotation = false;
        player.rotation = savedRotation;
        //player.transform.Rotate(savedRotation.eulerAngles * 100f * Time.deltaTime);



        pauseUI.SetActive(false);
    }

    public void quitGame()
    {
        GameObject.FindObjectOfType<GameManager>().QuitGame();
    }
}