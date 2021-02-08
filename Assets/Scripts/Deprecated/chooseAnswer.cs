﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseAnswer : MonoBehaviour
{
    //public AudioSource location;
    //public AudioClip sound;

    //public void playSound()
    //{
    //    location.clip = sound;
    //}

    public void goToLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void goToL1WrongAnswer()
    {
        SceneManager.LoadScene(4);
    }

    public void goToLevel2Intro()
    {
        SceneManager.LoadScene(5);
    }

    public void goToLevel2()
    {
        SceneManager.LoadScene(6);
    }

    public void goToL2WrongAnswer()
    {
        SceneManager.LoadScene(9);
    }

    public void goToLevel3Intro()
    {
        SceneManager.LoadScene(10);
    }

    public void goToLevel3()
    {
        SceneManager.LoadScene(11);
    }

    public void goToL3WrongAnswer()
    {
        SceneManager.LoadScene(14);
    }
    public void goToLevel4()
    {
        SceneManager.LoadScene(16);
    }

    public void goToL4WrongAnswer()
    {
        SceneManager.LoadScene(19);
    }

    public void goToLevel5()
    {
        SceneManager.LoadScene(21);
    }

    public void goToL5WrongAnswer()
    {
        SceneManager.LoadScene(24);
    }

    public void goBackTwoLevels()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex - 2);
    }

    public void beginNextLevel()
    {
        // go forward to next level (scene)
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

     
}
