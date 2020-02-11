using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    public AudioSource audio;
    public Text text;
    string url;

    public void select()
    {
        url = audio.clip.name;
        Debug.Log(url);


    }

   
}
