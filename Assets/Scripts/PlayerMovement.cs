using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 200f;

    bool canJump = true;

    void Start()
    {
        //Debug.Log("Hello, World!");
        //rb.useGravity = false;
        //rb.AddForce(0, 200, 500);
    }

    void FixedUpdate() //FixedUpdate is prefered over Update for handling physics
    {
        if (!PauseGame.isGamePaused)
        {
            print("force being added");
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // deltaTime accounts for differences in framerate

            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("a"))
            {
                rb.AddForce(-1 * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

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
            if (Input.GetButtonDown("Jump") && canJump)
            {
                Debug.Log("jump is false");
                rb.AddForce(0, 7.5f, 0, ForceMode.VelocityChange);
                canJump = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "The Ground" || other.collider.name == "Level 2 Ground")
        {
            Debug.Log("jump is true");
            canJump = true;
        }
    }


}
