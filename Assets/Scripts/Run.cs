using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public GameObject Sensor;
    ProjectData projectData = new ProjectData();
    string path;

    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(path))
        {
            string contents = System.IO.File.ReadAllText(path);
            JSONwrapper wrapper = JsonUtility.FromJson<JSONwrapper>(contents);
            projectData = wrapper.triggers;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Sensor.GetComponent<ConnectToServer>().SensorData == PlayerPrefs.GetString(PlayerPrefs.GetString("currentStory") + "rfid"))
        {

        }
    }

    public void setPath(string s){
        path = s;
    }

    public void readData()
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

                    if (i == "RFID")
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
}
