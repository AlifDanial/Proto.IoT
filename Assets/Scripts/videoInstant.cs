using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEditor;

public class videoInstant : MonoBehaviour
{
    public RawImage prefab;
    public RawImage prefab1;
    public VideoPlayer player;  
    public VideoPlayer player1;  
    RenderTexture rendertexture;
    public string path;

    public void Start()
    {
        Initialize();
    }

    public void Import()
    {
        RawImage o;

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

    public void Initialize()
    {
        RawImage o3;
        RenderTexture rendertexture1 = new RenderTexture(1920, 1080, 24);

        o3 = Instantiate(prefab1, transform);
        o3 = player.gameObject.GetComponent<RawImage>();
        o3.texture = rendertexture1;

        var vc = Resources.Load<VideoClip>("Video/candle");
        player1.clip = vc;        

        player1.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        player1.targetTexture = rendertexture1;
        player1.Play();

        RawImage o1;
        RenderTexture rendertexture2 = new RenderTexture(1920, 1080, 24);

        o1 = Instantiate(prefab1, transform);
        o1 = player.gameObject.GetComponent<RawImage>();
        o1.texture = rendertexture2;

        var vc1 = Resources.Load<VideoClip>("Video/earth");
        player1.clip = vc1;        

        player1.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        player1.targetTexture = rendertexture2;
        player1.Play();

        RawImage o2;
        RenderTexture rendertexture3 = new RenderTexture(1920, 1080, 24);

        o2 = Instantiate(prefab1, transform);
        o2 = player.gameObject.GetComponent<RawImage>();
        o2.texture = rendertexture3;

        var vc2 = Resources.Load<VideoClip>("Video/particle");
        player1.clip = vc2;

        player1.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        player1.targetTexture = rendertexture3;
        player1.Play();
        
    }

}
