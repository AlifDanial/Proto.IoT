using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    string filename;
    string path;
    ProjectData projectData = new ProjectData();

    // Start is called before the first frame update
    void Start()
    {
        
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveData()
    {
        JSONwrapper wrapper = new JSONwrapper();
        wrapper.triggers = projectData;
        string contents = JsonUtility.ToJson(wrapper, true);
        System.IO.File.WriteAllText(path, contents);
    }


    public void Save()
    { 

        filename = PlayerPrefs.GetString("fileName");               
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);

        PlayerPrefs.SetInt("Save", 1);

        for(int y = 1; y <= PlayerPrefs.GetInt("T"); y++)
        {
            TriggerData t = new TriggerData();
            t.trigger = y;
            t.inputType = PlayerPrefs.GetString("T" + y + "input");

            //save input
            if(PlayerPrefs.GetString("T" + y + "input") == "RFID")
            {
                Debug.Log("save rfid card");
            }
            else if (PlayerPrefs.GetString("T" + y + "input") == "Motion")
            {
                Debug.Log("save motion feedback");
            }
            else
            {
                Debug.Log("save touch feedback");
            }

            //save output
            if (PlayerPrefs.GetString("T" + y + "output") == "Audio")
            {
                t.audioURL = PlayerPrefs.GetString("audioURL" + y);
                Debug.Log("save audio URL feedback");
            }
            else if (PlayerPrefs.GetString("T" + y + "output") == "Image")
            {
                t.imageURL = PlayerPrefs.GetString("imageURL" + y);
                Debug.Log("save image URL feedback");
            }
            else if (PlayerPrefs.GetString("T" + y + "output") == "Text")
            {
                t.Texttext = PlayerPrefs.GetString("Text" + y);
                Debug.Log("save text URL feedback");
            }
            else 
            {
                t.videoURL = PlayerPrefs.GetString("videoURL" + y);
                Debug.Log("save video URL feedback");
            }

            projectData.triggers.Add(t);
        }

        SaveData();
        Debug.Log("Saved");
    }
}
