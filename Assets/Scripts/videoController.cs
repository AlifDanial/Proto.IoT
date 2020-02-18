using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoController : MonoBehaviour
{
    public VideoPlayer vp;
    public bool clicked = false;
    public string URL;

    public void select()
    {
        URL = vp.url;
        Debug.Log(URL);
        clicked = true;
    }

    public string getURL()
    {
        return URL;
    }


}
