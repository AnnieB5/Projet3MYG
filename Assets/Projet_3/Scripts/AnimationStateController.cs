using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    int isJumpingHash;
    private Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        //bool forwardPressed = Input.GetKey("w") || Input.GetKey("up");
        bool forwardPressed = (Input.GetAxis("Horizontal") <= -0.8f) || (Input.GetAxis("Horizontal") >= 0.8f)
         || (Input.GetAxis("Vertical") <= -0.8f) || (Input.GetAxis("Vertical") >= 0.8f);
        //bool forwardPressed = playerRigidBody.velocity != Vector3.zero;
        //Debug.Log(playerRigidBody.velocity.magnitude);

        // si le joueur appuie sur la touche w ou la flèche haut
        if (!isRunning && forwardPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        // sinon
        if (isRunning && !forwardPressed)
        {
            animator.SetBool(isRunningHash, false);
        }

    }

    public void PlayJumpingAnimation()
    {
        animator.SetTrigger(isJumpingHash);
 
    }
   
}
