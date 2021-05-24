using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script deals with the enabling and disabling of the game music. */
public class Music : MonoBehaviour
{
    public static bool musicActive = true;
    GameObject music;
    AudioSource source;

    /* Find the music GameObject and turn it off if the user has disabled music */
    public void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        source = music.GetComponent<AudioSource>();
        if (!musicActive)
        {
            source.enabled = false;
        }
    }

    /* turn on music if it is off; turn off music if it is on */
    public void toggleMusic()
    {
        if (musicActive)
        {
            source.enabled = false;
            musicActive = false;
        }
        else
        {
            source.enabled = true;
            musicActive = true;
        }       
    }
}
