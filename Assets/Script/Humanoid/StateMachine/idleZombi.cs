using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleZombi : StateMachineBehaviour
{
    private Transform player;
    private GameObject zombiself;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform.Find("Player");
        zombiself = animator.gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanse = Vector3.Distance(player.position, zombiself.transform.position);
        if(distanse > 1.5f)
        {
            animator.SetFloat("speed", 1f);
        }
        else
        {
            animator.SetBool("Attack", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    //OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
