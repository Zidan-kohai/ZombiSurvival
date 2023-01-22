using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class runPlayer : StateMachineBehaviour
{
    private MobileController joystick;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        joystick = GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<MobileController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (joystick.Horizontal() == 0 && joystick.Vertical() == 0)
        {
            animator.SetFloat("speed", 0f);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
