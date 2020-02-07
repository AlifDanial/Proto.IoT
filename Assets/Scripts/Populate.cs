using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Populate : MonoBehaviour    
{    
    public Button prefab;
    public string path;   

    public void Import()
    {
        Button o;
        Sprite Isprite;

        path = EditorUtility.OpenFilePanel("Import an Image", "", "jpg,png");
        if (path != null)
        {
            o = (Button)Instantiate(prefab, transform);
            WWW www = new WWW("file:///" + path);
            Isprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            o.GetComponent<Image>().sprite = Isprite;
        }
    }
}
