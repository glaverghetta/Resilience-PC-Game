using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{

    static public Color c = Color.cyan;

    public void goToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void begin()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            MeshRenderer renderer = player.GetComponent<MeshRenderer>();
            renderer.material.color = c;
            Debug.Log("test ");
        }
    }


    public void changeColorsToCyan() // set all player objects to specified color
    {
        c = Color.cyan;
    }
    public void changeColorsToGreen() // set all player objects to specified color
    {
        c = Color.green;
    }
    public void changeColorsToPurple() // set all player objects to specified color
    {
        c = new Color32(128, 0, 128, 255);
    }
    public void changeColorsToYellow() // set all player objects to specified color
    {
        c = Color.yellow;
    }
    public void changeColorsToOrange() // set all player objects to specified color
    {
        c = new Color32(255, 165, 0, 255);
    }
    public void changeColorsToBlue() // set all player objects to specified color
    {
        c = Color.blue;
    }
}
