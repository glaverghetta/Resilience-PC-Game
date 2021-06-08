using UnityEngine;

/* This class handles the player colliding with obstacles. */
public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody player;

    public delegate void PlayerCollisionDelegate();
    public event PlayerCollisionDelegate playerCollisionEvent;

    public delegate void HitGroundDelegate();
    public event HitGroundDelegate hitGroundEvent;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle" || collisionInfo.collider.tag == "Moving Obstacle")
        {
            if(playerCollisionEvent != null)
            {
                playerCollisionEvent(); // announce that the player collided with an obstacle
            }

            ////PauseGame.canGameBePaused = false;                  // these should happen in the classes that subscribed to the event upon colliding with obstacle
            ////player.useGravity = false;
            ////movement.enabled = false;
            ////FindObjectOfType<GameManager>().GameOver();

        }
        else if(collisionInfo.collider.tag == "Ground")
        {
            if(hitGroundEvent != null)
            {
                hitGroundEvent();   // announce that the player hit the ground
            }
        }
    }
}