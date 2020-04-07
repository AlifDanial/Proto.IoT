using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class ProjectName : MonoBehaviour
{
    public InputField input;
    public Text text1;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void StoreProjectName()
    {
        //PlayerPrefs.DeleteKey("ProjectName");
        string projectName = input.text;
        if (projectName == "")
        {
            projectName = "Unnamed Project";
        }

        PlayerPrefs.SetString("ProjectName", projectName);     
        PlayerPrefs.SetString("fileName", projectName + ".json");     
        
    }

    public void setName()
    {
        string name = Path.GetFileName(text1.text);
        name = name.Remove(name.Length - 5, 5);

        PlayerPrefs.SetString("ProjectName", name);
        PlayerPrefs.SetString("fileName", name + ".json");

        PlayerPrefs.SetInt("loadStatus", 1);
        PlayerPrefs.SetString("loadFile", text1.text);

    }

   
}
