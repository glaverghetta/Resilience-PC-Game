using UnityEngine;
using UnityEngine.SceneManagement;

public class StarRating : MonoBehaviour
{
    public static int currentStarRating = 3;
    public static int nextLevel = 2;

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
        FindObjectOfType<GameManager>().gameOverEvent -= OnGameOver;
        if(currentStarRating != 1)
        {
            currentStarRating = 2;
        }
    }

    public void OnWrongAnswer()
    {
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
