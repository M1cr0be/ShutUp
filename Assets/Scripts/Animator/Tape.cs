using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : StateMachineBehaviour
{
    PunchUniversal Punch;
    int GetOuttime;
    bool punched;
    Animator Anim;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetOuttime = 0;
        punched = false;
        Punch = animator.GetComponentInChildren<PunchUniversal>();
        Anim = animator.GetComponentInChildren<AnimObject>().GetComponent<Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetOuttime+= 1;

        if (GetOuttime > 20 && punched == false)
        {
            Punch.IsActive = true;
            punched = true;
        }

        if (GetOuttime > 60)
        {
            animator.SetBool("IsChasing", true);
            animator.SetBool("IsPunching", false);
            Punch.IsActive = false;


            Anim.SetBool("IsChasing", true);
            Anim.SetBool("IsPunching", false);
        }


            
        }
    }

    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

