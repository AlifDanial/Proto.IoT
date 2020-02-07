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

    public void select()
    {
        Debug.Log(this.gameObject.GetComponent<Image>().sprite.name);
        BackgroundURL = this.gameObject.GetComponent<Image>().sprite.name;
        Debug.Log(BackgroundURL);
    }  

}

