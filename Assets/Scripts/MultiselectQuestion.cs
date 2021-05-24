using UnityEngine;
using UnityEngine.UI;

/* This script handles the multi-select questions. */
public class MultiselectQuestion : MonoBehaviour
{
    public GameManager manager;

    public Toggle answer1;
    public Toggle answer2;
    public Toggle answer3;
    public Toggle answer4;

    public bool answer1Correct;
    public bool answer2Correct;
    public bool answer3Correct;
    public bool answer4Correct;

    /* Check if the answers given by the user match the correct answers. */
    public void checkAnswers()
    {
        
        if(answer1.isOn == answer1Correct && answer2.isOn == answer2Correct && answer3.isOn == answer3Correct && answer4.isOn == answer4Correct)
        {
            manager.LoadNextLevel();
        }
        else
        {
            manager.LoadSceneByName("Wrong Answer");
        }
    }
}
