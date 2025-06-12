using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    public static Unit Instance { get; set; }
    private float UH; // U nit H ealth
    public float UMH = 100; // U nit M ax H ealth
    public int UD = 15; // U nit D amage
    public HealthTracker HT;

    void Start()
    {
        USM_Script.Instance.AUL.Add(gameObject);

        UH = UMH;
        UpdateH();
    }

    private void UpdateH()
    {
        HT.UpdateSliderValue(UH, UMH);
        if (UH <= 0)
        {
            // Dying Logic
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        USM_Script.Instance.AUL.Remove(gameObject);
    }

    internal void TD(int DTI) // T ake D amage, D amage T o I nflict
    {
        UH -= DTI - 10;
        UpdateH();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

}
