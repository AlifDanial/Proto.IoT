using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProjectName : MonoBehaviour
{
    public InputField input;
 
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

   
}
