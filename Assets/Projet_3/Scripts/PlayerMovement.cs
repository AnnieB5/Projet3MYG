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
        playerMovementInput = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        //playerMovementInput.Normalize();

        MovePlayer();

        ///Vector3 movementDirection = playerRigidBody.velocity;

        ///movementDirection =  new Vector3(horizontalInput, 0, verticalInput);
        ///movementDirection.Normalize();

        ///transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        
        //Rotation du personnage en fonction de la direction donnée par Inputs (là où il y a PB)
        if (playerMovementInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovementInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            //Quaternion targetRotation = Quaternion.LookRotation(playerMovementInput);
            //targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //playerRigidBody.MoveRotation(targetRotation);
        }
        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        //transform.Translate(playerMovementInput * speed * Time.deltaTime, Space.World);

        /*Vector3 MoveVector = transform.TransformDirection(playerMovementInput) * speed;
        playerRigidBody.velocity = new Vector3(MoveVector.x, playerRigidBody.velocity.y, MoveVector.z);*/

        playerRigidBody.MovePosition(playerRigidBody.position + playerMovementInput * speed * Time.deltaTime);
    }
    void Jump()
    {
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        ///playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, jumpForce, playerRigidBody.velocity.z);
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

    
    private bool IsGrounded()
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
