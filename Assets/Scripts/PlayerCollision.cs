using UnityEngine;

/* This class handles the player colliding with obstacles. */
public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody player;

    public delegate void PlayerCollisionDelegate();
    public event PlayerCollisionDelegate playerCollisionEvent;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle" || collisionInfo.collider.tag == "Moving Obstacle")
        {
            if(playerCollisionEvent != null)
            {
                playerCollisionEvent(); // announce that the player collided with an obstacle
            }


            ////PauseGame.canGameBePaused = false;
            ////player.useGravity = false;
            ////movement.enabled = false;
            ////FindObjectOfType<GameManager>().GameOver();
            
        }

    }
}
