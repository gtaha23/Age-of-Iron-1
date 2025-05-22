using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class USM_Script : MonoBehaviour
{
    public static USM_Script Instance { get; set; }

    public List<GameObject> AUL = new List<GameObject>(); // A ll U nits L ist
    public List<GameObject> US = new List<GameObject>(); // U nits S elected

    public LayerMask clickable;
    public LayerMask ground;
    public GameObject groundMarker;

    private Camera cam;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            // If we are hitting a clickable object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift)) 
                {
                    MS(hit.collider.gameObject);
                }
                else
                {
                    SBC(hit.collider.gameObject);
                }

            }
            // If we are NOT hitting a clickable object
            else
            {
                if (Input.GetKey(KeyCode.LeftShift) == false) 
                {
                    DeselectAll();
                }
            }


        }
        if (Input.GetMouseButtonDown(1) && US.Count > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // If we are hitting a clickable object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                groundMarker.transform.position = hit.point;

                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }


    }

    private void MS(GameObject unit) // M ulti S elect
    {
        if (US.Contains(unit) == false) 
        {
            US.Add(unit);
            TSI(unit, true);
            EUM(unit, true);
        }
        else
        {
            EUM(unit, false);
            TSI(unit, false);
            US.Remove(unit);
        }
    }

    private void DeselectAll()
    {
        foreach (var unit in US)
        {
            EUM(unit, false);
            TSI(unit, false);
        }

        groundMarker.SetActive(false);
        US.Clear();
    }

    private void SBC(GameObject unit) // S elect By C licking
    {
        DeselectAll();
        US.Add(unit);

        TSI(unit, true);
        EUM(unit, true);
    }

    private void EUM(GameObject unit, bool canMove)
    {
        unit.GetComponent<UnitMovement>().enabled = canMove;
    }

    private void TSI(GameObject unit, bool isVisible)
    {
        unit.transform.GetChild(0).gameObject.SetActive(isVisible);
    }
}
