using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    MeshRenderer spriteRenderer;
    int ground;
    void Start()
    {
        spriteRenderer = GetComponent<MeshRenderer>();
        ground = LayerMask.GetMask("Ground");
    }
    void Update()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       

       if(!Physics.Raycast(ray, out hit, 10000, ground)){
            spriteRenderer.enabled = false;
       }else {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            spriteRenderer.enabled = true;
       }
    }
}
