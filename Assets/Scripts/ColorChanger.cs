using UnityEngine;

/* This script can be used to change the color of all obstacles in a level */
public class ColorChanger : MonoBehaviour
{
    public Color obstacleColor;
    void Start()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");     // find all objects tagged "Obstacle"
        foreach(GameObject obstacle in obstacles)
        {
            if (obstacle.gameObject.name.IndexOf("JumpObstacle") == -1)             // JumpObstacles should not have their colors changed
            {
                obstacle.GetComponent<MeshRenderer>().material.color = obstacleColor;   // change color of obstacles
            }
        }

        GameObject[] movingObstacles = GameObject.FindGameObjectsWithTag("Moving Obstacle");     // find all objects tagged "Moving Obstacle"
        foreach (GameObject obstacle in movingObstacles)
        {
            obstacle.GetComponent<MeshRenderer>().material.color = obstacleColor;   // change color of obstacles
        }
    }
}
