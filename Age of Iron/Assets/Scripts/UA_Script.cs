using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UA_Script : MonoBehaviour
{
    [SerializeField] private GameObject enemy; // Assign the enemy GameObject in the Inspector
    private Unit attackerUnit;

    private void Awake()
    {
        attackerUnit = GetComponent<Unit>();
    }

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
        int damage = attackerUnit != null ? attackerUnit.UD : 0;
        enemy.RD(damage);
        if (attackerUnit != null)
        {
            attackerUnit.TD(damage);
        }
    }

}