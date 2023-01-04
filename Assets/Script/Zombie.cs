using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Player player;
    CapsuleCollider capsuleCollider;
    Animator animator;
    MovementAnimator movementAnimator;
    public bool death;
    public bool died;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();    
        navMeshAgent.updateRotation = false;

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        movementAnimator = GetComponent<MovementAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death){
            if (!died)
            {
                Destroy(gameObject, 3);
                died = true;
            }
            return;
        }
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(player.transform.position);
            transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        }
    }

    public void Kill()
    {   
        if (!death) {
            death = true;
            Destroy(capsuleCollider);
            Destroy(movementAnimator);
            Destroy(navMeshAgent);
            animator.SetTrigger("died");
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}