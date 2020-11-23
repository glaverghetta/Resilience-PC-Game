using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public Rigidbody player;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            player.useGravity = false;
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }

        if(collisionInfo.collider.name == "The Ground")
        {
            
        }
    }
}
