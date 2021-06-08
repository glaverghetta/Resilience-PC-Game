using UnityEngine;

/* This script controls the movement of the camera, causing it to follow the player. */
public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}