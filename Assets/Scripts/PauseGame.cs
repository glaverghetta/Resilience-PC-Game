using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Rigidbody player;
    Vector3 savedVelocy;                        // velocty that the player had at the moment that the game is paused
    bool gravityWasOn;                          // was gravity enabled when the game was paused?

    public GameObject pauseUI;                  // UI that appears when the game is paused

    public static bool canGameBePaused = true;  // is the game in a state where pausing is feasible right now?
    public static bool isGamePaused = false;    // is the game currently paused?

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
                isGamePaused = true;
                //PlayerMovement.isGamePaused = true;
                gravityWasOn = player.useGravity;

                player.useGravity = false;
                savedVelocy = player.velocity;
                player.velocity = Vector3.zero;

                pauseUI.SetActive(true);
            }
        }
    }

    public void backToMainMenu()
    {
        player.useGravity = true;
        isGamePaused = false;
        print(isGamePaused);
        SceneManager.LoadScene(0);
    }

    public void unpause()
    {
        isGamePaused = false;
        if(gravityWasOn)
            player.useGravity = true;

        //PlayerMovement.isGamePaused = false;
        player.velocity = savedVelocy;

        pauseUI.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}