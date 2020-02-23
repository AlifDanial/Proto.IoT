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
    public string url;
    public Clickable clicks;

    public void select()
    {
        url = audio.clip.name;
        clicks.AudioURL = url;
        Debug.Log(url);
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
