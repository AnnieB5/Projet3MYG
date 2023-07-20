using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private int isRunningHash;
    private int isJumpingHash;
    private Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        isRunningHash = Animator.StringToHash("isRunning"); //Lie les références de l'Animator au script
        isJumpingHash = Animator.StringToHash("isJumping"); //Lie les références de l'Animator au script
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = (Input.GetAxis("Horizontal") <= -0.8f) || (Input.GetAxis("Horizontal") >= 0.8f)
        || (Input.GetAxis("Vertical") <= -0.8f) || (Input.GetAxis("Vertical") >= 0.8f);


        //Si l'animation de course du personnage n'est pas jouée ET si le joueur appuie sur la touche w ou la flèche haut pour avancer
        if (!isRunning && forwardPressed)
        {
            //Joue l'animation de course du personnage
            animator.SetBool(isRunningHash, true);
        }

        //Si l'animation de course du personnage est jouée ET si le joueur n'appuie pas sur une touche pour avancer le personnage
        if (isRunning && !forwardPressed)
        {
            //Sort de l'animation de course du personnage
            animator.SetBool(isRunningHash, false);
        }
    }

    public void PlayJumpingAnimation()
    {
        //Joue l'animation de saut du personnage
        animator.SetTrigger(isJumpingHash);
    }
}
