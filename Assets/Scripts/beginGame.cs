using UnityEngine;
using UnityEngine.SceneManagement;

/* This class handles the Main Menu scene. */
public class beginGame : MonoBehaviour
{
    public GameObject welcomeScreen;
    public GameObject instructions;
    public GameObject starRatingText;

    public void begin()
    {
        SceneManager.LoadScene(1);
    }

    /* Display the specified UI element */
    public void showComponent(GameObject component)
    {
        if (component.name.Equals("Star Rating"))
        {
            component.SetActive(true);
            instructions.SetActive(false);
        }
        else
        { 
            component.SetActive(true);
            welcomeScreen.SetActive(false);
        }
    }

    /* Hide the specified UI element */
    public void hideComponent(GameObject component)
    {
        if (component.name.Equals("Star Rating"))
        {
            instructions.SetActive(true);
            component.SetActive(false);
        }
        else
        {
            welcomeScreen.SetActive(true);
            component.SetActive(false);
        }
    }

    public void goToChangeColor()
    {
        SceneManager.LoadScene(26);
    }
}