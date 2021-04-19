using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static bool musicActive = true;
    GameObject music;
    AudioSource source;

    public void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        source = music.GetComponent<AudioSource>();
        if (!musicActive)
        {
            print("got here");
            //music.gameObject.GetComponent("Audio Source").gameObject.SetActive(false);
            source.enabled = false;
        }
    }

    /* turn on music if it is off; turn off music if it is on */
    public void toggleMusic()
    {
        if (musicActive)
        {
            print("false");
            source.enabled = false;
            musicActive = false;
        }
        else
        {
            print("true");
            source.enabled = true;
            //music.gameObject.GetComponent("Audio Source").gameObject.SetActive(true);
            musicActive = true;
        }       
    }
}
