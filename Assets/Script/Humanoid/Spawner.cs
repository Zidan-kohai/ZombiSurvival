using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float deltaTime;
    public GameObject zombie;
    public ParticleSystem spawnEffect;
    void Start()
    {
        InvokeRepeating("Spawn", 2f, deltaTime);
    }

    void Spawn()
    {
        spawnEffect.Play();
        Instantiate(zombie,transform.position,transform.rotation);
    }
}
