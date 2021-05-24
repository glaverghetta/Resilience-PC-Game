using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This class handles of the color of the player model, allowing it to be changed by the user in the Change Color scene. */
public class ChangeColor : MonoBehaviour
{
    public static Color c = Color.cyan;     // The color chosen by the player in the Change Color scene

    void Start()
    {
        // Find the player object, if it exists, and set its color
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            MeshRenderer renderer = player.GetComponent<MeshRenderer>();
            renderer.material.color = c;
        }
    }

    public void changeColorsToCyan()
    {
        c = Color.cyan;
    }
    public void changeColorsToGreen()
    {
        c = Color.green;
    }
    public void changeColorsToPurple()
    {
        c = new Color32(128, 0, 128, 255);
    }
    public void changeColorsToYellow()
    {
        c = Color.yellow;
    }
    public void changeColorsToOrange()
    {
        c = new Color32(255, 165, 0, 255);
    }
    public void changeColorsToBlue()
    {
        c = Color.blue;
    }
}
