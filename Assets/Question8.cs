using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Question8 : MonoBehaviour
{

    public Toggle answer1;
    public Toggle answer2;
    public Toggle answer3;
    public Toggle answer4;

    public void checkAnswers()
    {
        
        if(!answer1.isOn && answer2.isOn && answer3.isOn && !answer4.isOn)
        {
            SceneManager.LoadScene(20);
        }
        else
        {
            SceneManager.LoadScene(19);
        }
    }
}
