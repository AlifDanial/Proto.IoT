using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoController : MonoBehaviour
{
    public VideoPlayer vp;
    public bool clicked = false;
    public string URL = "";
    public Clickable clicks;

    public void select()
    {
        
        if(vp.url == "")
        {
            URL = vp.clip.name;            
        }
        else
        {
            URL = vp.url;          
        }

        clicks.VideoURL = URL;
        Debug.Log(URL);
        clicked = true;
    }

    public string getURL()
    {
        return URL;
    }


}
