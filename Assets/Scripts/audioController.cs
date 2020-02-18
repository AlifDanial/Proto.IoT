using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    public AudioSource audio;
    public Text text;
    string url;
    public bool clicked = false;

    public void select()
    {
        url = audio.clip.name;
        Debug.Log(url);
        clicked = true;
    }

    public void Update()
    {        
        string file = Path.GetFileName(audio.clip.name);
        text.text = file;
    }

    public string getURL()
    {
        return url;
    }

   
}
