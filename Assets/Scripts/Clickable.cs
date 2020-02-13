using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public ImageSelector imageselector;
    public videoController videocontrol;
    public audioController audiocontrol;
    public TextCheck textchecker;
    public Popup popup;
    public Logo logo;

   public void close(GameObject go)
    {
        if(imageselector.clicked == true)
        {
            Debug.Log(imageselector.clicked);
            imageselector.clicked = false;
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    public void closeText(GameObject go)
    {
        if(textchecker.isEmpty() == false)
        {
            Debug.Log(textchecker.isEmpty());
            textchecker.savereset();
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    public void closeVideo(GameObject go)
    {
        if (videocontrol.clicked == true)
        {
            Debug.Log(videocontrol.clicked);
            videocontrol.clicked = false;
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    public void closeAudio(GameObject go)
    {
        if (audiocontrol.clicked == true)
        {
            Debug.Log(audiocontrol.clicked);
            audiocontrol.clicked = false;
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }
}
