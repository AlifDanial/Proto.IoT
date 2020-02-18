using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImageSelector : MonoBehaviour
{
    public Button prefab;
    public string BackgroundURL;
    public string path;
    public bool clicked = false;

    public void select()
    {        
        BackgroundURL = this.gameObject.GetComponent<Image>().sprite.name;
        Debug.Log(BackgroundURL);
        clicked = true;
    }  

    public string getURL()
    {
        return BackgroundURL;
    }
}

