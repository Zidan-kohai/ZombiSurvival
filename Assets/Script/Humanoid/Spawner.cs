using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float deltaTime;
    public GameObject zombie;
    void Start()
    {
        InvokeRepeating("Spawn", 2f, deltaTime);
    }

    void Spawn()
    {
        Instantiate(zombie,transform.position,transform.rotation);
    }
}
