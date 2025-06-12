using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UA_Script : MonoBehaviour
{
    [SerializeField] GameObject enemy; // Assign the enemy GameObject in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        Enemy_Script enemy = other.GetComponent<Enemy_Script>();
        if (enemy != null)
        {
            Attack(enemy);
        }
    }

    private void Attack(Enemy_Script enemy)
    {
        int damage = GetComponent<Unit>().UD;
        enemy.RD(damage);
        Unit.Instance.TD(damage);
    }

}