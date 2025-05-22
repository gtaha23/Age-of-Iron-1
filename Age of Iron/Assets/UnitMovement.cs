using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    public LayerMask gnd;

    private void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gnd)) 
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
