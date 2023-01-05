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
    public bool death;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();    
        navMeshAgent.updateRotation = false;

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanse = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (navMeshAgent != null && distanse > 1f)
        {
            navMeshAgent.SetDestination(player.transform.position);
            transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        }
    }

    public void Kill()
    {   
        if (!death) {
            
            Destroy(gameObject, 3);
            Destroy(this);

        }
    }

    private void OnDestroy()
    {
        death = true;
            Destroy(capsuleCollider);
            Destroy(navMeshAgent);
            animator.SetTrigger("died");
            GetComponentInChildren<ParticleSystem>().Play(); 
    }
}