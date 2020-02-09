using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public ImageSelector imageselector;
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
            logo.OutputReady();
            popup.PopupClose(go);
        }
    }
}
