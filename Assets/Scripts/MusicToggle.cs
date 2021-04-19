using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public Toggle musicOnOff;

    void Start()
    {
        if(Music.musicActive)
        {
            musicOnOff.isOn = true;
        }
        else
        {
            musicOnOff.isOn = false;
        }
    }
}
