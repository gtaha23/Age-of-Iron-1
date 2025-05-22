using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fox_Save : MonoBehaviour
{
    [SerializeField] TMP_Text saveWarning;
    public void SavePos(Vector3 playerPos)
    {
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetFloat("posZ", playerPos.z);

        PlayerPrefs.Save();

        saveWarning.text = "Kayýt baþarýlý!";

        Invoke(nameof(DeleteText), 2f);
    }
    public void DeleteText()
    {
        saveWarning.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = other.transform.position;
            SavePos(pos);
        }
    }
}
