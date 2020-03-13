using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    string filename;
    string path;
    ProjectData projectData = new ProjectData();
    public Run run;
    int i=0;

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
        run.setPath(path);
        ReadData();
    }

    public void ReadData()
    { 
        try
        {
            if (System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JSONwrapper wrapper = JsonUtility.FromJson<JSONwrapper>(contents);
                projectData = wrapper.triggers;

                foreach (TriggerData s in projectData.triggers)
                {
                    int t = s.trigger;
                    Debug.Log("trigger value = " + t);

                    string i = s.inputType;
                    Debug.Log("input type = " + i);

                    if(i == "RFID")
                    {
                        Debug.Log("card data = " + s.RFIDcard);
                    }
                    else if (i == "Motion")
                    {
                        Debug.Log("Motion");
                    }
                    else
                    {
                        Debug.Log("Touch");
                    }

                    string o = s.outputType;
                    Debug.Log("output type = " + o);

                    if (o == "Audio")
                    {
                        string audioURL = s.audioURL;
                        Debug.Log("audio URL = " + audioURL);
                    }
                    else if (o == "Image")
                    {
                        string imageURL = s.imageURL;
                        Debug.Log("image URL = " + imageURL);
                    }
                    else if (o == "Text")
                    {
                        string text = s.Texttext;
                        Debug.Log("text = " + text);
                    }
                    else
                    {
                        string video = s.videoURL;
                        Debug.Log("video URL = " + video);
                    }
                }
                    
               
            }
            else
            {
                Debug.Log("Unable to read the save data, file does not exist");               
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }    


    public void Save()
    { 

        filename = PlayerPrefs.GetString("fileName");               
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);

        int l = PlayerPrefs.GetInt("T");
        l += i;

        PlayerPrefs.SetInt("Save", 1);

        for (int y = i+1; y <= l; y++)
        {
            TriggerData t = new TriggerData();
            t.trigger = y;

            t.inputType = PlayerPrefs.GetString("T" + y + "input");

            //save input
            if(PlayerPrefs.GetString("T" + y + "input") == "RFID")
            {
                t.RFIDcard = PlayerPrefs.GetString("T" + y + "card");
            }
            else if (PlayerPrefs.GetString("T" + y + "input") == "Motion")
            {
                t.Motion = PlayerPrefs.GetString("T" + y + "input");
            }
            else
            {
                t.Touch = PlayerPrefs.GetString("T" + y + "input");
            }

            t.outputType = PlayerPrefs.GetString("T" + y + "output");

            //save output
            if (PlayerPrefs.GetString("T" + y + "output") == "Audio")
            {
                t.audioURL = PlayerPrefs.GetString("audioURL" + y);
                Debug.Log(PlayerPrefs.GetString("audioURL" + y));
                Debug.Log("save audio URL feedback");
            }
            else if (PlayerPrefs.GetString("T" + y + "output") == "Image")
            {
                t.imageURL = PlayerPrefs.GetString("imageURL" + y);
                Debug.Log(PlayerPrefs.GetString("imageURL" + y));
                Debug.Log("save image URL feedback");
            }
            else if (PlayerPrefs.GetString("T" + y + "output") == "Text")
            {
                t.Texttext = PlayerPrefs.GetString("Text" + y);
                Debug.Log(PlayerPrefs.GetString("Text" + y));
                Debug.Log("save text URL feedback");
            }
            else 
            {
                t.videoURL = PlayerPrefs.GetString("videoURL" + y);
                Debug.Log(PlayerPrefs.GetString("videoURL" + y));
                Debug.Log("save video URL feedback");
            }

            projectData.triggers.Add(t);
            
            /*PlayerPrefs.DeleteKey("T" + y + "input");            
            PlayerPrefs.DeleteKey("T" + y + "card");            
            PlayerPrefs.SetInt("T",PlayerPrefs.GetInt("T") - 1);            
            PlayerPrefs.DeleteKey("T" + y + "output");
            PlayerPrefs.DeleteKey("audioURL" + y);
            PlayerPrefs.DeleteKey("imageURL" + y);
            PlayerPrefs.DeleteKey("Text" + y);
            PlayerPrefs.DeleteKey("videoURL" + y);
            Debug.Log("deleted " + y + " times");*/

            i = y;
        }

        Debug.Log("Saved");
        SaveData();
        
    }
}
