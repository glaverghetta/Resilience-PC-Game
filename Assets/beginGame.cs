﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class beginGame : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene(1);
    }

    public void goToChangeColor()
    {
        SceneManager.LoadScene(16);
    }
}


