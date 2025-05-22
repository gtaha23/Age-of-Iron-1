using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{


    void Start()
    {
        USM_Script.Instance.AUL.Add(gameObject);
    }

    private void OnDestroy()
    {
        USM_Script.Instance.AUL.Remove(gameObject);
    }

}
