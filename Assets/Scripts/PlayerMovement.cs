using UnityEngine;

/* This class controls the movement of the player through the world, including forward movement, sideways movement, and jumping. */
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 200f;       // forward force applied to the player
    public float sidewaysForce = 200f;      // force used to move left or right

    bool canJump = true;
    bool canMove = true;

    void Start()
    {
        FindObjectOfType<QuestionsInLevel>().finishedMovingEvent += enableMovement;
        FindObjectOfType<PlayerCollision>().playerCollisionEvent += disableMovement;
    }

    void FixedUpdate() //FixedUpdate is prefered over Update for handling physics
    {
        if (!PauseGame.isGamePaused && canMove)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // deltaTime accounts for differences in framerate
            rb.AddForce(Input.GetAxisRaw("Horizontal") * sidewaysForce * Time.deltaTime, 0, 0);

            /*Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal") * sidewaysForce, 0, 0);
            Vector3 forwardMovement = new Vector3(0, 0, 1 * forwardForce);
            Vector3 moveAmount = (moveInput + forwardMovement) * Time.deltaTime;
            rb.velocity = moveAmount;*/

            //Vector3 3 moveVelocity = moveInput.normalized * 

            

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
        if (other.collider.name == "The Ground")
        {
            canJump = true;
        }
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
