using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionsInLevel : MonoBehaviour
{
    public GameObject rightAnswerUI;
    public GameObject wrongAnswerUI;
    public GameObject answerQuestionUI;

    public GameObject[] moveBackPoints;
    public GameObject player;
    public Rigidbody playerRigidBody;

    public PlayerMovement movement;

    void Start()
    {
        moveBackPoints = GameObject.FindGameObjectsWithTag("Move back point");

        foreach(GameObject p in moveBackPoints)
        {
            print(p.transform.position.z);
        }
    }

    public void RightAnswer()
    {
        rightAnswerUI.SetActive(true);
        answerQuestionUI.SetActive(false);
    }

    public void MovePlayer()
    {
        playerRigidBody.useGravity = true;
        rightAnswerUI.SetActive(false);
 
        float playerZ = player.transform.position.z;
        GameObject pointToTravelTo = moveBackPoints[0];

        for(int i = 1; i < moveBackPoints.Length; i++)
        {
            print(moveBackPoints[i].transform.position.z + " " + playerZ);
            if(moveBackPoints[i].transform.position.z < playerZ && moveBackPoints[i].transform.position.z > pointToTravelTo.transform.position.z)
            {
                print("inside if");
                pointToTravelTo = moveBackPoints[i];
                print(pointToTravelTo.transform.position.z);
            }
        }

        Vector3 vectorToTravel = new Vector3(pointToTravelTo.transform.position.x, pointToTravelTo.transform.position.y, pointToTravelTo.transform.position.z);

        StartCoroutine(MoveOverSeconds(player, vectorToTravel, 1.5f));
    }

    IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //transform.position = end;
        FindObjectOfType<GameManager>().CanGameOverAgain();
        movement.enabled = true;
        
    }

    IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(player.transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

    }

    public void WrongAnswer()
    {
        wrongAnswerUI.SetActive(true);
        gameObject.SetActive(false);
        answerQuestionUI.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

}
