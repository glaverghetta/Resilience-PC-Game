using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This class manages the Questions that are asked inside each level. It handles the asking of the questions and receives the player's answers. */
public class QuestionsInLevel : MonoBehaviour
{
    public GameObject rightAnswerUI;
    public GameObject wrongAnswerUI;
    public GameObject answerQuestionUI;

    public GameObject[] moveBackPoints;
    public GameObject earliestMoveBackPoint;
    public GameObject player;
    public Rigidbody playerRigidBody;

    public PlayerMovement movement;

    public delegate void ShowQuestionDelegate();
    public event ShowQuestionDelegate showQuestionEvent;    // Event called when the question is displayed on screen

    public delegate void WrongAnswerDelegate();
    public event WrongAnswerDelegate wrongAnswerEvent;      // Event called when the question is answered incorrectly

    public delegate void MovingPlayerDelegate();
    public event MovingPlayerDelegate movingPlayerEvent;    // Event called when the player starts being moved after correctly answering the question

    public delegate void FinishedMovingPlayer();
    public event FinishedMovingPlayer finishedMovingEvent;  // Event called when the player has reached their destination after correctly answering the question

    void Start()
    {
        FindObjectOfType<GameManager>().restartLevelEvent += ShowQuestion;

        // Find all move back points in the scene
        moveBackPoints = GameObject.FindGameObjectsWithTag("Move back point");

        // Determine which move back point is closest to the start of the level
        earliestMoveBackPoint = moveBackPoints[0];
        for(int i = 1; i < moveBackPoints.Length; i++)
        {
            if (moveBackPoints[i].transform.position.z < earliestMoveBackPoint.transform.position.z)
                earliestMoveBackPoint = moveBackPoints[i];
        }
    }

    /* Shows the question in the level */
    void ShowQuestion()
    {
        answerQuestionUI.SetActive(true);
        if(showQuestionEvent != null)
        {
            showQuestionEvent();
        }
    }

    /* The player correctly answered the question in the level */
    public void RightAnswer()
    {
        rightAnswerUI.SetActive(true);
        answerQuestionUI.SetActive(false);
    }

    /* Moves the player slightly back in the level after they correctly answer the question */
    public void MovePlayer()
    {
        rightAnswerUI.SetActive(false);
 
        float playerZ = player.transform.position.z;
        GameObject pointToTravelTo = earliestMoveBackPoint;

        // Determine which point to send the player to. They should be sent to the closest point that is not further in the level.
        for(int i = 1; i < moveBackPoints.Length; i++)
        {
            if(moveBackPoints[i].transform.position.z < playerZ && moveBackPoints[i].transform.position.z > pointToTravelTo.transform.position.z)
            {
                pointToTravelTo = moveBackPoints[i];
            }
        }

        Vector3 vectorToTravel = pointToTravelTo.transform.position; //(pointToTravelTo.transform.position.x, pointToTravelTo.transform.position.y, pointToTravelTo.transform.position.z);

        StartCoroutine(MoveOverSeconds(player, vectorToTravel, 1.5f));
    }

    // Moves objectToMove from its current location to end over time seconds
    IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        if(movingPlayerEvent != null)
        {
            movingPlayerEvent(); // announce that the player has started moving
        }
        ////PauseGame.canGameBePaused = false;
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if(finishedMovingEvent != null)
        {
            finishedMovingEvent();
        }

        ////player.useGravity = true;
        ////movement.enabled = true;
        ////PauseGame.canGameBePaused = true;

    }

    /*IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(player.transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

    }*/

    public void WrongAnswer()
    {
        if(wrongAnswerEvent != null)
        {
            wrongAnswerEvent();     // announce that the player answered the question incorrectly
        }

        wrongAnswerUI.SetActive(true);
        gameObject.SetActive(false);
        answerQuestionUI.SetActive(false);
    }

    public void ReloadScene()
    {
        FindObjectOfType<GameManager>().LoadSceneByName("Level Welcome Screen");
    }

}
