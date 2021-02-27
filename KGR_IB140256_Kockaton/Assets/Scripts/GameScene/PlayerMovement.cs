using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    public float sidewaysSpeed = 12.0f;
    public float forwardsSpeed = 50.0f;
    public float jumpSpeed = 12.0f;
    private float verticalVelocity = 0.0f;
    public float gravity = 44.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpSpeed;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        if (transform.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * sidewaysSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = forwardsSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        forwardsSpeed = 50.0f + newSpeed;
    }

    public void SetJumpSpeed(float newSpeed)
    {
        jumpSpeed = 12 + newSpeed;
    }
}

