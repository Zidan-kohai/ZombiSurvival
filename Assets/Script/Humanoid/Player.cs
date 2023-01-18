using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Cursor cursor;
    public Light FlashLight;
    public Shot shot;
    public Transform gunBarrel;

    [SerializeField] private float moveSpeed;
    [SerializeField] private int _helth = 100;
    public bool GameStop;
    [SerializeField] PanelManager panelManager;

    public Text Helth;
    
    private MobileController joystick;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }
    
    private void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();
        navMeshAgent.velocity = -dir.normalized * moveSpeed;
        
        Vector3 forward = cursor.transform.position - transform.position;
        if(Vector3.Angle(Vector3.forward, dir) > 1f || Vector3.Angle(Vector3.forward, dir) == 0f)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, dir, moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        

        FlashLightTurnOn();
    }

    private void FlashLightTurnOn()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashLight.enabled = FlashLight.enabled == true ? false : true;
        }
    }

    public void GetDamage(int damage)
    {
        _helth -= damage;
        Helth.text = _helth.ToString();
        if(_helth <= 0)
        {
            panelManager.GameFail();
        }
    }

    public void Shot()
    {
        var from = gunBarrel.position;
        var target = cursor.transform.position;
        var to = new Vector3(target.x, from.y, target.z);

        var direction = (to - from).normalized;
        RaycastHit hit;
        if (Physics.Raycast(from, direction, out hit, 1000))
        {
            if (hit.transform != null)
            {
                var zombie = hit.transform.GetComponent<Zombie>();
                if (zombie != null)
                    zombie.Kill();
            }
            to = new Vector3(hit.point.x, from.y, hit.point.z);
        }
        else
            to = from + direction * 100;

        shot.Show(from, to);
    }
}