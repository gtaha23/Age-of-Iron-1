using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fox_Coins : MonoBehaviour
{
    Fox_Logic FL;

    public string objName;
    public bool isTaken;
    void Start()
    {
        FL = FindObjectOfType<Fox_Logic>();

        if (PlayerPrefs.HasKey(objName))
        {
            isTaken = PlayerPrefs.GetInt(objName) == 1;
            gameObject.SetActive(!isTaken);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTaken = true;
            PlayerPrefs.SetInt(objName, 1);
            gameObject.SetActive(false);
            int value = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", value+1);

            FL.GetCoin();
        }
    }
}
