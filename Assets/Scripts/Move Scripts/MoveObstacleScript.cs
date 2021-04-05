using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script can be used to move a particular obstacle or obstacles either to the left or to the right over a specified period of time. */

public class MoveObstacleScript : MonoBehaviour
{
    public GameObject obstacleToMove;   // which obstacle to be moved
    public GameObject obstacleToMove2;  // another obstacle to be moved

    public float directionToMove;       // positive: to the player's left. negative: to the player's right.
    public float directionToMove2;

    public float timeTaken;             // how long will the move take (in seconds)
    public float timeTaken2;

    bool flag = false;
    void OnTriggerEnter()
    {
        if (flag)
        {
            return;
        }
        flag = true;

        Vector3 distance = new Vector3(directionToMove, 0, 0);
        StartCoroutine(MoveOverSeconds(obstacleToMove, obstacleToMove.transform.position - distance, timeTaken));

        if(obstacleToMove2 != null)
        {
            Vector3 distance2 = new Vector3(directionToMove2, 0, 0);
            StartCoroutine(MoveOverSeconds(obstacleToMove2, obstacleToMove2.transform.position - distance2, timeTaken2));
        }

    }

    // moves objectToMove towards end over seconds
    IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            // stop moving the obstacle while the game is paused
            if (!PauseGame.isGamePaused)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
            } 

            yield return new WaitForEndOfFrame();
            
        }
    }
}
