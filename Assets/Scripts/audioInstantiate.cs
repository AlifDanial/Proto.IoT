using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using SimpleFileBrowser;

public class audioInstantiate : MonoBehaviour
{
    public Image prefab;
    public AudioSource audios;
    public string path;
    public string url;


    public void Import()
    {
        #if UNITY_EDITOR
        path = EditorUtility.OpenFilePanel("Import an Audio File", "", "mp3");
        #endif        
        if (path.Length != 0)
        {
            Image o;
            o = Instantiate(prefab, transform);
            StartCoroutine(LoadAudio(path));            

        }
    }

    IEnumerator LoadAudio(string path)
    {
                    
            url = "file:///" + path;
            WWW www = new WWW(url);
            yield return www;

            audios.clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
            audios.clip.name = path;            
            audios.Play();
            
        
    }


}
