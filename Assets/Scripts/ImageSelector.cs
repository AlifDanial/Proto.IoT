using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImageSelector : MonoBehaviour
{
    public Button prefab;
    public string BackgroundURL = "";
    public Clickable clicks;

    public void select()
    {        
        BackgroundURL = this.gameObject.GetComponent<Image>().sprite.name;
        clicks.ImageURL = BackgroundURL;
        Debug.Log(BackgroundURL);
    }  

    public string getURL()
    {
        return BackgroundURL;
    }
}

