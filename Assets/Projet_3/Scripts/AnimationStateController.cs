using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w") || Input.GetKey("up");

        // si le joueur appuie sur la touche w ou la flèche haut
        if (!isRunning && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        // sinon
        if (isRunning && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
