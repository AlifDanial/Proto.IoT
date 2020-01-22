using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetProjectName : MonoBehaviour
{
    public Text projectName;


    public void Start()
    {
        string name = PlayerPrefs.GetString("ProjectName","Unnamed Project");
        projectName.text = name;
    }
    
    



}
