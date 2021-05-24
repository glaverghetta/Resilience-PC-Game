using UnityEngine;
using UnityEngine.SceneManagement;

/*  SCENES:
 *  
 *  0 = Start
 *  1 = Change Color
 *  2 = Level Welcome Screen
 *  3 = Wrong Answer
 *  4, 5, 6 = Level 1, Question 1, Question 2
 *      - Pattern repeats for the rest of the levels
 * 
 *  Penultimate = EndGame
 *  Last = Star Rating
 * 
 */

/* This class handles the overall flow of the game, including scene transitions, completing levels, and gaming over. */
public class GameManager : MonoBehaviour
{
    public const int TOTAL_LEVELS = 5;              // Total levels in the game.

    private static int currentLevel = 0;            // The level the player is currently on.
    public static int CurrentLevel
    {
        get { return currentLevel;  }
        set { currentLevel = value; }
    }

    public static bool playSound = false;           // Should the correct answer sound be played?

    static int questionsScene = 0;                  // build index of the next question scene

    bool hasEnded = false;                          // Has the player already lost?
    public float restartDelay = 1f;                 // How long before the restart function is called after the player hits a wall

    //public GameObject completeLevelUI;              // UI that displays after completing a level
    //public GameObject answerQuestionUI;             // UI that displays when prompted to answer a question in the level
    //public Rigidbody player;                        // Player's rigidbody

    public delegate void GameOverDelegate();
    public event GameOverDelegate gameOverEvent;    // Event called when the player games over

    public delegate void RestartLevelDelegate();
    public event RestartLevelDelegate restartLevelEvent;    // Event called when the level restarts

/*    public delegate void LevelCompleteDelegate();
    public event LevelCompleteDelegate levelCompleteEvent;  // Event called when the player completes a level*/

    void Start()
    {
        // If a player object exists in the current scene, this is one of the game levels (not a question scene or menu)
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            // The scene that contains the next question will have a build index 1 greater than the current level
            questionsScene = SceneManager.GetActiveScene().buildIndex + 1;
        }

        if (FindObjectOfType<QuestionsInLevel>() != null)
        {
            FindObjectOfType<QuestionsInLevel>().finishedMovingEvent += CanGameOverAgain;
        }

        if (FindObjectOfType<PlayerCollision>() != null)
        {
            FindObjectOfType<PlayerCollision>().playerCollisionEvent += GameOver;
        }
    }

    /* Scene management functions */
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        // Calling this function from a Question scene indicates that the player just answered a question correctly.
        if (SceneManager.GetActiveScene().name.IndexOf("Question") != -1)
            playSound = true;
        else
            playSound = false;

        CurrentLevel++;
        if (CurrentLevel > TOTAL_LEVELS)
        {
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            SceneManager.LoadScene("Level Welcome Screen");
        }
    }

    public void LoadNextLevel(int level)
    {
        CurrentLevel = level;
        SceneManager.LoadScene("Level Welcome Screen");
    }

    public void BeginLevel()
    {
        string levelName = "Level " + CurrentLevel;
        SceneManager.LoadScene(levelName);
    }


    public void GoToQuestions()
    {
        SceneManager.LoadScene(questionsScene);
    }

    /* Player has gamed over */
    public void GameOver()
    {
        if (!hasEnded)
        {
            hasEnded = true;

            if(gameOverEvent != null)
            {
                gameOverEvent();    // announce that game over has occured
            }

            Invoke("Restart", restartDelay);
        }
    }

    public void CanGameOverAgain()
    {
        hasEnded = false;
    }

    void Restart()
    {
        if(restartLevelEvent != null)
        {
            restartLevelEvent();    // announce that the level has restarted
        }

        ////answerQuestionUI.SetActive(true);
        ////PauseGame.canGameBePaused = true;
    }

    /* Quits the game. */
    public void QuitGame()
    {
        Application.Quit();
    }

}