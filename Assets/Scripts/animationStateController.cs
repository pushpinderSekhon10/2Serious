using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalking;
    int isAttacking;
    int isRunning;
    int isStrafing;
    int isBack;
    int isLightAttacking;
    int isBlocking;
    [SerializeField] GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalking = Animator.StringToHash("walk");
        isAttacking = Animator.StringToHash("attack");
        isRunning = Animator.StringToHash("run");
        isStrafing = Animator.StringToHash("strafe");
        isBack = Animator.StringToHash("back");
        isLightAttacking = Animator.StringToHash("attackLight");
        isBlocking = Animator.StringToHash("block");
    }

    // Update is called once per frame
    void Update()
    {
        bool walking = animator.GetBool(isWalking);
        bool attacking = animator.GetBool(isAttacking);
        bool running = animator.GetBool(isRunning);
        bool strafing = animator.GetBool(isStrafing);
        bool backing = animator.GetBool(isBack);
        bool lightAttacking = animator.GetBool(isLightAttacking);
        bool blocking = animator.GetBool(isBlocking);
        bool walk = Input.GetKey("w");
        bool attack = Input.GetKey("q");
        bool run = Input.GetKey("r");
        bool strafe = Input.GetKey("a");
        bool strafe2 = Input.GetKey("d");
        bool backUp = Input.GetKey("s");
        bool lightAttack = Input.GetKey("e");
        bool block = Input.GetKey("f");

        if (!walking && walk)
        {
            animator.SetBool(isWalking, true);
            animator.SetBool(isRunning, false);
        }

        if (walking && !walk) 
        {
            animator.SetBool(isWalking, false);
           
           
        }
        if (walk && run)
        {
            animator.SetBool(isRunning, true);
        }
        if (running && !run)
        {
            animator.SetBool(isRunning, false);
        }

        if (!attacking && attack)
        {
            animator.SetBool (isAttacking, true);
        
        }
        if (attacking && !attack)
        {
            animator.SetBool(isAttacking, false);

        }
        if (!lightAttacking && lightAttack)
        {
            animator.SetBool(isLightAttacking, true);

        }
        if (lightAttacking && !lightAttack)
        {
            animator.SetBool(isLightAttacking, false);

        }

        if (!strafing && strafe)
        {
            animator.SetBool(isStrafing, true);
        }

        if (strafing && !strafe)
        {
            animator.SetBool(isStrafing, false);
        }
        if (!strafing && strafe2)
        {
            animator.SetBool(isStrafing, true);
        }

        if (strafing && !strafe2)
        {
            animator.SetBool(isStrafing, false);
        }
        if (!backing && backUp)
        {
            animator.SetBool(isBack, true);

        }
        if (backing && !backUp)
        {
            animator.SetBool(isBack, false);

        }
        if (!blocking && block)
        {
            animator.SetBool(isBlocking, true);

        }
        if (blocking && !block)
        {
            animator.SetBool(isBlocking, false);

        }

    }
    public GameObject Weapon
    {
        get { return weapon; }
    }

    public void StartDealDamage()
    {
        weapon.GetComponentInChildren<DamageDealer>().StartDealDamage();

    }

    public void EndDealDamage()
    {
        weapon.GetComponent<DamageDealer>().EndDealDamage();
    }
}
