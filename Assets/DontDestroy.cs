using System.Collections;
using UnityEngine;

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
