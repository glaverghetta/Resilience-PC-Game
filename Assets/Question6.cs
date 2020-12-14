using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Question6 : MonoBehaviour
{
    // GameObject answer1 = GameObject.Find("Q6Answer 1");
    // GameObject answer2 = GameObject.Find("Q6Answer 2");
    // GameObject answer3 = GameObject.Find("Q6Answer 3");
    // GameObject answer4 = GameObject.Find("Q6Answer 4");

    public Toggle answer1;
    public Toggle answer2;
    public Toggle answer3;
    public Toggle answer4;

    public void checkAnswers()
    {
        
        if(!answer1.isOn && !answer2.isOn && answer3.isOn && answer4.isOn)
        {
            SceneManager.LoadScene(13);
        }
        else
        {
            SceneManager.LoadScene(12);
        }
    }
}
