using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReadyStatus : MonoBehaviour
{
    public Logo logo;

    public void Ready()
    {
        logo.InputReady();
    }
}
