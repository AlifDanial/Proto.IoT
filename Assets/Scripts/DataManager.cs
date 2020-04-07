using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    string filename;
    string path;
    ProjectData projectData = new ProjectData();
    public StartMenu sm;
    public Run run;
    int i=0;
    string temp = "";
    public bool loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        run.enabled = false;
                
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

        if(temp != path && loaded == false)
        {
            temp = path;
            sm.setSave(path);
            sm.readPath();
        }
       
        run.setPath(path);
        run.enabled = true;        
        //ReadData();
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
                    Debug.Log("Trigger = " + t);

                    string i = s.input;
                    Debug.Log("input = " + i);

                    string o = s.output;
                    Debug.Log("output = " + o);
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
        //l = l - i;
        Debug.Log("i = " + i);
        Debug.Log("l = " + l);

        PlayerPrefs.SetInt("Save", 1);

        for (int y = i+1; y <= l; y++)
        {
            TriggerData t = new TriggerData();
            t.trigger = y;

            t.input = PlayerPrefs.GetString("sensor" + y);
            t.output = PlayerPrefs.GetString(PlayerPrefs.GetString("sensor" + y));            
            t.outputType = PlayerPrefs.GetString("outputType" + y);            

            projectData.triggers.Add(t);

            PlayerPrefs.DeleteKey("sensor" + y);            
            PlayerPrefs.DeleteKey(PlayerPrefs.GetString("sensor" + y));            
            PlayerPrefs.DeleteKey("outputType" + y);                       
                                             
            i = y;
            Debug.Log("y = " + y);
        }
        
        Debug.Log("Saved");
        SaveData();
        
    }

    public void stopRun()
    {
        run.stopScan();
        run.enabled = false;
    }
}
