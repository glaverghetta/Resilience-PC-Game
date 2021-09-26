using UnityEngine;

/* This script controls the movement of the camera, causing it to follow the player. */
public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private bool hasCollided = false;


    private void Start()
    {
        if (FindObjectOfType<PlayerCollision>() != null)
        {
            FindObjectOfType<PlayerCollision>().playerCollisionEvent += StopCameraFollow;
        }

        if (FindObjectOfType<QuestionsInLevel>() != null)
        {
            FindObjectOfType<QuestionsInLevel>().finishedMovingEvent += StartCameraFollow;
        }
    }

    void Update()
    {
        if(!hasCollided)
            transform.position = player.position + offset;

    }

    void StopCameraFollow()
    {
        hasCollided = true;
    }

    void StartCameraFollow()
    {
        hasCollided = false;
    }

    public Vector3 GetOffset()
    {
        return offset;
    }
}