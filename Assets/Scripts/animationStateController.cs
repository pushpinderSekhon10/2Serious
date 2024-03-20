using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalking;
    int isAttacking;
    int isRunning;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalking = Animator.StringToHash("walk");
        isAttacking = Animator.StringToHash("attack");
        isRunning = Animator.StringToHash("run");
    }

    // Update is called once per frame
    void Update()
    {
        bool walking = animator.GetBool(isWalking);
        bool attacking = animator.GetBool(isAttacking);
        bool running = animator.GetBool(isRunning);
        bool walk = Input.GetKey("s");
        bool attack = Input.GetKey("q");
        bool run = Input.GetKey("w");

        if (!walking && walk)
        {
            animator.SetBool(isWalking, true);
        }

        if (walking && !walk) 
        {
            animator.SetBool(isWalking, false);
        }

        if (!attacking && attack)
        {
            animator.SetBool (isAttacking, true);
        
        }
        if (attacking && !attack)
        {
            animator.SetBool(isAttacking, false);

        }
        if (!running && run)
        {
            animator.SetBool(isRunning, true);

        }
        if (running && !run)
        {
            animator.SetBool(isRunning, false);

        }




    }
}
