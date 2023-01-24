using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Player player;
    CapsuleCollider capsuleCollider;
    Animator animator;
    public bool death;
    [SerializeField] private float health;
    [SerializeField] private Slider HealthBar;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();    
        navMeshAgent.updateRotation = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        HealthBar.maxValue = health;
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

    public void GetDamage(int damage)
    {
        health -= damage;
        if (!death && health <= 0) {
            
            Destroy(gameObject, 3);
            Destroy(HealthBar.gameObject);
            Destroy(this);
        }
        HealthBar.value = health; 
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