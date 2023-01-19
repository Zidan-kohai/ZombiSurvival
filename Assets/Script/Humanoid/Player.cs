using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Light FlashLight;
    public Shot shot;
    public Transform gunBarrel;
    [SerializeField] private float timeToNextShoot;
    [SerializeField] private float currentTimeAfterShoot;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int _helth = 100;
    public bool GameStop;
    [SerializeField] PanelManager panelManager;
    [SerializeField] private Animator playerAnim;

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
        
        if(Vector3.Angle(Vector3.forward, dir) > 1f || Vector3.Angle(Vector3.forward, dir) == 0f)
        {   
            Vector3 direct = Vector3.RotateTowards(transform.forward, -dir, rotateSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        currentTimeAfterShoot += Time.deltaTime;
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
        if (currentTimeAfterShoot > timeToNextShoot)
        {
            var from = gunBarrel.position;
            Vector3 to = new Vector3();

            var direction = transform.forward;
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
            playerAnim.Play("Shoot");
            currentTimeAfterShoot = 0;
        }
    }

    public void FlashLightTurnOn() => FlashLight.enabled = FlashLight.enabled == true ? false : true;
}