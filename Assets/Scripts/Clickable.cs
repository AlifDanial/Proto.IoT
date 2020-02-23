using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public ImageSelector imageselector;
    public videoController videocontrol;
    public audioController audiocontrol;
    public TextCheck textchecker;
    public makeTrigger mt;
    public Popup popup;
    public Logo logo;


   public void close(GameObject go)
    {
        if(imageselector.clicked == true)
        {
            Debug.Log("clickable clicked status = " + imageselector.clicked);
            mt.setImageURL(imageselector.getURL());
            logo.OutputReady();
            popup.PopupClose(go);
            imageselector.clicked = false;
        }
        else
        {
            Debug.Log("It aint true but false fam");
        }
    }

    public void closeText(GameObject go)
    {
        if(textchecker.isEmpty() == false)
        {
            Debug.Log(textchecker.isEmpty());
            textchecker.savereset();
            mt.setText(textchecker.getText());            
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    public void closeVideo(GameObject go)
    {
        if (videocontrol.clicked == true)
        {
            Debug.Log("clickable clicked status for video  = " + videocontrol.clicked);
            videocontrol.clicked = false;
            mt.setVideoURL(videocontrol.getURL());
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
            mt.setAudioURL(audiocontrol.getURL());
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    
}

