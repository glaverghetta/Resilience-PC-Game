using UnityEngine;
using UnityEngine.SceneManagement;

/* This class manages the Star Ratings that the player earns after completing each level. */
public class StarRating : MonoBehaviour
{
    public static int currentStarRating = 3;        // The star rating that the player has for the level they are currently playing
    public static int nextLevel = 2;                // build index of the questions scene following the current level (1 + build index of current level, refer to GameManager.cs for arrangement of scenes)

    public GameObject oneStarUI;
    public GameObject twoStarsUI;
    public GameObject threeStarsUI;

    void Start()
    {
        // if we are in the Star Rating scene, show the player's rating, else watch for game overs and wrong answers
        if (SceneManager.GetActiveScene().name == "Star Rating")
        {
            ShowRating();
        }
        else
        {
            nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            FindObjectOfType<GameManager>().gameOverEvent += OnGameOver;
            FindObjectOfType<QuestionsInLevel>().wrongAnswerEvent += OnWrongAnswer;
        }

        
    }

    public void OnGameOver()
    {
        // Colliding with an obstacle sets the player's rating to 2 if it is not already 1
        FindObjectOfType<GameManager>().gameOverEvent -= OnGameOver;
        if(currentStarRating != 1)
        {
            currentStarRating = 2;
        }
    }

    public void OnWrongAnswer()
    {
        // Incorrectly answering a question in a level sets the star rating to 1
        FindObjectOfType<QuestionsInLevel>().wrongAnswerEvent -= OnWrongAnswer;
        currentStarRating = 1;
    }

    public void ShowRating()
    {
        if(currentStarRating == 1)
        {
            oneStarUI.SetActive(true);
        }
        else if(currentStarRating == 2)
        {
            twoStarsUI.SetActive(true);
        }
        else
        {
            threeStarsUI.SetActive(true);
        }
        currentStarRating = 3;
    }

    public void goToQuestions()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
