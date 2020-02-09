using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoController : MonoBehaviour
{
    public VideoPlayer vp;

    public void select()
    {
        string URL = vp.url;
        Debug.Log(URL);
    }


}
