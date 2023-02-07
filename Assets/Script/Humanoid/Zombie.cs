using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private PanelManager panelManager;
    private NavMeshAgent navMeshAgent;
    private CapsuleCollider capsuleCollider;
    private GameObject money;
    private Player player;
    private Animator animator;
    public bool death;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();    
        navMeshAgent.updateRotation = false;

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        panelManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PanelManager>();
        money = transform.Find("Money").gameObject;
    }

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
            int f = Convert.ToInt32(panelManager.CountKill.text);
            f++;
            panelManager.CountKill.text = f.ToString();
            Destroy(gameObject, 3);
            money.SetActive(true);
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