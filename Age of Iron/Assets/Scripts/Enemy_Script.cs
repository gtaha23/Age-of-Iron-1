using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public int Health;

    internal void RD(int DTI) // R eceive D amage
    {
        Health -= DTI;
    }
}
