using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public static Enemy_Script Instance {  get; private set; }
    public float Health;
    public float MaxHealth = 150;

    public HealthTracker EHT; // E nemy H ealth T racker

    void Start()
    {
        Health = MaxHealth;
        UpdateH();
    }

    internal void RD(int DTI) // R eceive D amage
    {
        Health -= DTI;
        UpdateH();

    }
    private void UpdateH()
    {
        EHT.UpdateSliderValue(Health, MaxHealth);
        if (Health <= 0)
        {
            // Dying Logic
            Destroy(gameObject);
        }
    }

}
