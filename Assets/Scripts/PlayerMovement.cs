using UnityEngine;

/* This class controls the movement of the player through the world, including forward movement, sideways movement, and jumping. */
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 200f;       // forward force applied to the player
    public float sidewaysForce = 200f;      // force used to move left or right

    //bool gravityWasOn;                          // was gravity enabled when the game was paused?
    //Vector3 savedVelocity;                        // velocty that the player had at the moment that the game is paused
    //Vector3 savedVelocityDirection;             // the direction that the player was moving when the game was paused
    //Quaternion savedRotation;                   // the player's rotation at the moment the game was paused

    bool canJump = true;
    bool canMove = true;

    void Start()
    {
        if (FindObjectOfType<QuestionsInLevel>() != null)
        {
            FindObjectOfType<QuestionsInLevel>().finishedMovingEvent += enableMovement;
        }

        if (FindObjectOfType<PlayerCollision>() != null)
        {
            FindObjectOfType<PlayerCollision>().playerCollisionEvent += disableMovement;
            FindObjectOfType<PlayerCollision>().playerCollisionEvent += OnHitGround;
            FindObjectOfType<PlayerCollision>().hitGroundEvent += OnHitGround;
        }

        /*if(FindObjectOfType<PauseGame>() != null)
        {
          *//*  FindObjectOfType<PauseGame>().pauseGameEvent += OnPauseGame;
            FindObjectOfType<PauseGame>().unpauseGameEvent += OnUnpauseGame;*//*
        }*/

    }

    void FixedUpdate() //FixedUpdate is prefered over Update for handling physics
    {
        if (!PauseGame.isGamePaused && canMove)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // deltaTime accounts for differences in framerate
            rb.AddForce(Input.GetAxisRaw("Horizontal") * sidewaysForce * Time.deltaTime, 0, 0);

            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }       

    }

    void Update()
    {
        if (!PauseGame.isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.AddForce(0, 7.5f, 0, ForceMode.VelocityChange);
                canJump = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            canJump = true;
        }
    }

    /*void OnPauseGame()
    {
        gravityWasOn = rb.useGravity;

        rb.useGravity = false;
        savedVelocity = rb.velocity;
        //savedVelocityDirection = rb.velocity.normalized;
        rb.velocity = Vector3.zero;
        savedRotation = rb.rotation;
        rb.freezeRotation = true;
    }

    void OnUnpauseGame()
    {
        if (gravityWasOn)
            rb.useGravity = true;

        performRotation = true;
        rb.velocity = savedVelocity;
        rb.freezeRotation = false;
    }
*/
    void OnHitGround()
    {
        //performRotation = false;
    }

    void enableMovement()
    {
        rb.useGravity = true;
        canMove = true;
        canJump = true;
    }

    void disableMovement()
    {
        rb.useGravity = false;
        canMove = false;
        canJump = false;
    }

}
