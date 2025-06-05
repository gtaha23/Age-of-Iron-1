using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UA_Script : MonoBehaviour
{
    [SerializeField] GameObject enemy; // Assign the enemy GameObject in the Inspector
    public float AR = 1f; // A ttack R ate
    public float AS; // A ttack S peed

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        // Check if the object is the enemy GameObject
        if (other.gameObject == enemy)
        {
            if (AS <= 0)
            {
                Attack();
                AS = 1f/AR;
            }
        }
        else
        {
            Debug.Log("Ignored object: " + other.gameObject.name);
        }
    }

    private void Attack()
    {
        var DTI = GetComponent<Unit>().UD;
        GetComponent<Enemy_Script>().RD(DTI);
    }
}
