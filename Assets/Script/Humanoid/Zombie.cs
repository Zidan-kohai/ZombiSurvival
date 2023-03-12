using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private PanelManager panelManager;
    private NavMeshAgent navMeshAgent;
    private CapsuleCollider capsuleCollider;
    private GameObject money;
    private Player player;
    private Animator animator;
    public bool death;
    private int health;
    private Vector3 cameraPosition;

    void Start()
    {
        health = Convert.ToInt32((Time.timeSinceLevelLoad / 15f) + 1);
        healthSlider.maxValue = health;
        healthSlider.value = health;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();    
        navMeshAgent.updateRotation = false;

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        panelManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PanelManager>();
        money = transform.Find("Money").gameObject;

        cameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        healthSlider.transform.LookAt(cameraPosition);
        float distanse = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (navMeshAgent != null && distanse > 1f)
        {
            navMeshAgent.SetDestination(player.transform.position);
            transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        }
    }

    public void Kill(int damage)
    {   
        health -= damage;
        healthSlider.value = health < 0 ? 0 : health;
        if (!death && health <= 0) {
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