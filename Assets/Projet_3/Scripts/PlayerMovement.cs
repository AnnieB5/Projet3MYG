using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Vector3 playerMovementInput;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private AnimationStateController animationStateControllerScript;
    //[SerializeField] Transform groundCheck;
    public LayerMask ground;
    public float raycastDistance = 0.1f;
    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerMovementInput = new Vector3(horizontalInput, 0f, verticalInput);
        
        //Rotation du personnage en fonction de la direction donnée par Inputs (là où il y a PB)
        if (playerMovementInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovementInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            animationStateControllerScript.PlayJumpingAnimation();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 playerMovementInputFixed = new Vector3(horizontalInput, 0f, verticalInput);
        playerRigidBody.MovePosition(playerRigidBody.position + playerMovementInput * speed * Time.deltaTime);
    }
    void Jump()
    {
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    
    public bool IsGrounded()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
        //return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
