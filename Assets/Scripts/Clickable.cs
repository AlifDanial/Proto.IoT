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
    
    public string ImageURL = "";
    public string AudioURL = "";
    public string VideoURL = "";


   public void close(GameObject go)
    {
        if(ImageURL != "")
        {
            Debug.Log(ImageURL);
            mt.setImageURL(ImageURL);
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
            mt.setText(textchecker.getText());            
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    public void closeVideo(GameObject go)
    {
        if (VideoURL != "")
        {
            Debug.Log(VideoURL);
            mt.setVideoURL(VideoURL);
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    public void closeAudio(GameObject go)
    {
        if (AudioURL != "")
        {
            Debug.Log(AudioURL);
            mt.setAudioURL(AudioURL);
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }

    
}

