using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEditor;

public class videoInstant : MonoBehaviour
{
    public RawImage prefab;
    public VideoPlayer player;
    public RenderTexture texture;
    public string path;

    public void Import()
    {
        RawImage o;
        Sprite Isprite;

        path = EditorUtility.OpenFilePanel("Import a Video Clip", "", "asf,avi,dv,m4v,mov,mpg,mp4,mpeg,ogv,vp8,wbm,wmv");
        if (path.Length != 0)
        {
            o = Instantiate(prefab, transform);
            WWW www = new WWW("file:///" + path);
            //Isprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));            
            player.url = path;
            player.targetTexture = texture;
            o.texture = texture;
        }
    }

}
