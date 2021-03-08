using UnityEngine;
using UnityEngine.SceneManagement;

public class beginGame : MonoBehaviour
{
    public GameObject welcomeScreen;
    public GameObject instructions;
    public GameObject starRatingText;

    public void begin()
    {
        SceneManager.LoadScene(1);
    }

    public void showInstructions()
    {
        welcomeScreen.SetActive(false);
        instructions.SetActive(true);
    }

    public void hideInstructions()
    {
        welcomeScreen.SetActive(true);
        instructions.SetActive(false);
    }

    public void showStarRatingText()
    {
        welcomeScreen.SetActive(false);
        starRatingText.SetActive(true);
    }

    public void hideStarRatingText()
    {
        welcomeScreen.SetActive(true);
        starRatingText.SetActive(false);
    }

    public void goToChangeColor()
    {
        SceneManager.LoadScene(26);
    }
}


