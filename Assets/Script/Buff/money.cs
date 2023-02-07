using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    [SerializeField] private AnimationCurve height;
    [SerializeField] private PanelManager panelManager;
    private float CurrentTime = 0;
    private float maxTime;
    private void Start()
    {
        maxTime = height.keys[height.length - 1].time;
        panelManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PanelManager>();
    }
    void Update()
    {
        if (CurrentTime > maxTime) CurrentTime = 0;
        transform.position = new Vector3(transform.position.x, height.Evaluate(CurrentTime), transform.position.z);

        CurrentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int f = Convert.ToInt32(panelManager.CountMoney.text);
            f++;
            panelManager.CountMoney.text = f.ToString();
            Destroy(gameObject);
        }
    }
}
