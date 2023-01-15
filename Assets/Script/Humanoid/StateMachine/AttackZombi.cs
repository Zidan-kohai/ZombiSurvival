using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZombi : StateMachineBehaviour
{

    private GameObject player;
    private GameObject Zombiself;
    [SerializeField] private int _damage;
    [SerializeField] private float _animationTime;
    private float _currentTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.Find("Player").gameObject;
        Zombiself = animator.gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanse = Vector3.Distance(player.transform.position, Zombiself.transform.position);
        if (distanse > 1.5f)
        {
            animator.SetBool("Attack", false);
            animator.SetFloat("speed", 1f);
        }
        Zombiself.transform.LookAt(player.transform.position);
        if (_currentTime > _animationTime)
        {
            player.GetComponentInChildren<Player>().GetDamage(_damage);
            _currentTime = 0f;
        }
        else
        {
            _currentTime += Time.deltaTime;
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
