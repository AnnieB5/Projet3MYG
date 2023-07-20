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
    public LayerMask ground;
    public float raycastDistance = 0.1f;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] private Transform raySourceTransform;

    //DEBUG laisser en comm'
    //public bool isGroundedTest;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Récupères les entrées claviers paramétrées pour aller à gauche et à droite, selon l'axe horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        //Récupères les entrées claviers paramétrées pour aller en haut et en bas, selon l'axe vertical
        float verticalInput = Input.GetAxis("Vertical");

        //Enregistre en un vecteur tridimensionnel les entrées claviers de direction
        playerMovementInput = new Vector3(horizontalInput, 0f, verticalInput);
        
        //Rotation du personnage en fonction de la direction donnée par Inputs
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

        //DEBUG laisser en comm'
        //isGroundedTest = IsGrounded();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //Récupères les entrées claviers paramétrées pour aller à gauche et à droite, selon l'axe horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        //Récupères les entrées claviers paramétrées pour aller en haut et en bas, selon l'axe vertical
        float verticalInput = Input.GetAxis("Vertical");

        //Enregistre en un vecteur tridimensionnel les entrées claviers de direction
        Vector3 playerMovementInputFixed = new Vector3(horizontalInput, 0f, verticalInput);

        //Bouge le personnage selon les entrées claviers citées plus haut
        playerRigidBody.MovePosition(playerRigidBody.position + playerMovementInput * speed * Time.deltaTime);
    }
    public void Jump()
    {
        //Fait sauter le personnage
        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //Joue un bruitage de saut
        jumpSound.Play();
    }
    
    public bool IsGrounded()
    {
        RaycastHit hit;

        //Si le rayon de détection du personnage, pointé vers le bas à ses pieds (comment ?), de longueur 0.1f (raycastDistance), touche une couche nommée "ground"
        if(Physics.Raycast(raySourceTransform.position, Vector3.down, out hit, raycastDistance, ground))
        {
            //DEBUG LAISSER EN COMM
            //Affiche en pointillés le raycast en rouge pendant les deux dernières secondes
            Debug.DrawRay(raySourceTransform.position, Vector3.down*raycastDistance, Color.red, 2);
            return true;
        }
        else
        {
            return false;
        }
    }
}
