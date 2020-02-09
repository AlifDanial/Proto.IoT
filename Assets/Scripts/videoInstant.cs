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
    RenderTexture rendertexture;
    public string path;

    public void Import()
    {
        RawImage o;
        Sprite Isprite;

        path = EditorUtility.OpenFilePanel("Import a Video Clip", "", "asf,avi,dv,m4v,mov,mpg,mp4,mpeg,ogv,vp8,wbm,wmv");
        if (path.Length != 0)
        {
            rendertexture = new RenderTexture(1920, 1080, 24);

            o = Instantiate(prefab, transform);
            o = player.gameObject.GetComponent<RawImage>();
            o.texture = rendertexture;

            WWW www = new WWW("file:///" + path);            
            player.url = path;
            
            player.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
            player.targetTexture = rendertexture;
            player.Play();
        }
    }

}
