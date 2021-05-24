using UnityEngine;
using UnityEngine.UI;

/* This class manages the Level Welcome Screen and the Wrong Answer scenes. */
public class WelcomeScreenWrongAnswer : MonoBehaviour
{
    public Text levelTextUI;
    public Image background;
    public AudioSource source;

    public bool isWelcomeScreen;

    int currentLevel = GameManager.CurrentLevel;

    void Start()
    {
        SetBackgroundColor();
        CheckForSound();

        if (isWelcomeScreen)
        {
            levelTextUI.text = "Get ready for\n\nLevel " + currentLevel;
        }
    }

    /* Sets the background color of the scene to the desired value */
    public void SetBackgroundColor()
    {
        Color32 bgColor;

        switch (currentLevel)
        {
            case 1:
            case 2:
                bgColor = new Color32(89, 185, 253, 255);
                background.color = bgColor;
                break;
            case 3:
                bgColor = new Color32(131, 171, 209, 255);
                background.color = bgColor;
                break;
            case 4:
                bgColor = new Color32(202, 202, 202, 255);
                background.color = bgColor;
                break;
            case 5:
                bgColor = new Color32(241, 233, 199, 255);
                background.color = bgColor;
                break;
        }
    }

    /* Play the correct answer sound if appropriate. Prevent the sound from being played again until the player correctly answers the two questions at the end of a level. */
    public void CheckForSound()
    {
        if(GameManager.playSound)
        {
            AudioSource sound = Instantiate(source, Vector3.zero, Quaternion.identity) as AudioSource;
            GameManager.playSound = false;
        }
    }

}
