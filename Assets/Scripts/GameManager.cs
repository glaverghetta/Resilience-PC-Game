using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    bool hasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public GameObject answerQuestionUI;
    public Rigidbody player;


    /* private void Start()
     {
         Debug.Log("starting");
         if(playerColor == Color.green)
         {
             Debug.Log("color is green");
         }
         GameObject player = GameObject.FindGameObjectWithTag("Player");
         if (player != null)
         {
             MeshRenderer renderer = player.GetComponent<MeshRenderer>();
             renderer.material.color = playerColor;
         }
     }

     public void changeColorToCyan()
     {
         playerColor = Color.cyan;
     }

     public void changeColorToGreen()
     {
         playerColor = Color.green;
         Debug.Log("Green now");
     } */

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true); //enables the level completion ui
    }

    public void GameOver()
    {
        if (!hasEnded)
        {
            hasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void CanGameOverAgain()
    {
        hasEnded = false;
        player.useGravity = true;
    }

    void Restart()
    {
        answerQuestionUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
