﻿using System.Collections;
using UnityEngine;

public class MoveScript5 : MonoBehaviour
{
    bool flag = false;
    void OnTriggerEnter()
    {
        if (flag)
        {
            return;
        }
        flag = true;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Moving Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            GameObject obstacle;
            if (obstacles[i].name == "Move Obstacle 7")
            {
                obstacle = obstacles[i];
                Vector3 distance = new Vector3(20f, 0, 0);
                StartCoroutine(MoveOverSeconds(obstacle, obstacle.transform.position - distance, 1f));
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
