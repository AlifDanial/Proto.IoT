using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLoad : MonoBehaviour
{
    public MP3Import mp3;

    public void importAudio()
    {
        mp3.StartImport();
    }
}
