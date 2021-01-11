using System.Collections;
using UnityEngine;

public class MoveScript1 : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Debug.Log("got here");
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Moving Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            GameObject obstacle;
            if(obstacles[i].name == "Move Obstacle 1")
            {
                obstacle = obstacles[i];
                Vector3 distance = new Vector3(14f, 0, 0);
                StartCoroutine( MoveOverSeconds(obstacle, obstacle.transform.position - distance, 3f) );
            }
        }
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
    }
}


