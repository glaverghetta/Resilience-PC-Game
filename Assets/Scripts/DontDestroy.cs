using System.Collections;
using UnityEngine;

/* This script allows a game object to persist across scenes, which is useful for some elements of the game (namely, the background music) */
public class DontDestroy : MonoBehaviour
{
    //runs as soon as the object gets created
    void Awake()
    {
        //prevent two copies of the background music from playing at the same time
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
