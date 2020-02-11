using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class audioInstantiate : MonoBehaviour
{
    public Image prefab;
    public AudioSource audios;
    public string path;
    public string url;


    public void Import()
    {

        path = EditorUtility.OpenFilePanel("Import an Audio File", "", "mp3");
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

            audios.clip = www.GetAudioClip(false, true);
            audios.Play();
            //Isprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            //o.GetComponent<Image>().sprite = Isprite;
            //o.GetComponent<Image>().sprite.name = path;
        
    }


}
