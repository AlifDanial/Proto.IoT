using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProjectName : MonoBehaviour
{
    public string projectName;
    public GameObject inputField;
    private ProtoDevManager protodevmanager;

    void Awake()
    {
        protodevmanager = GameObject.FindObjectOfType<ProtoDevManager> ();
    }

    public void StoreProjectName()
    {
        projectName = inputField.GetComponent<Text>().text;
        protodevmanager.UpdateName(projectName);
    }

   
}
