using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    string saved;
    ProjectData projectData = new ProjectData();
    public GameObject Prefab;
    public GameObject go;
    public Text[] Txtcol;
    private Text saveName;
    private Text hidden;
    public Text deleteT;
    public bool redundant = false;

    // Start is called before the first frame update
    void Start()
    {
        saved = Application.persistentDataPath + "/" + "Saves.json";
        readPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSave(string path)
    {
        checkRedundancy(path);
        if(redundant != true)
        {
            SaveData s = new SaveData();
            s.savepath = path;
            projectData.saves.Add(s);
            Wrapper wrapper = new Wrapper();
            wrapper.saves = projectData;
            string contents = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(saved, contents);
        }
        else
        {
            Debug.Log("Redundant FilePath");
        }

       
    }

    public void checkRedundancy(string path)
    {
        try
        {
            if (File.Exists(saved))
            {
                string contents = System.IO.File.ReadAllText(saved);
                Wrapper wrapper = JsonUtility.FromJson<Wrapper>(contents);
                projectData = wrapper.saves;

                foreach (SaveData s in projectData.saves)
                {
                    if (s.savepath == path)
                    {
                        redundant = true;
                    }
                    else
                    {
                        redundant = false;
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

    public void delete()
    {
        try
        {
            if (File.Exists(saved))
            {
                string contents = System.IO.File.ReadAllText(saved);
                Wrapper wrapper = JsonUtility.FromJson<Wrapper>(contents);
                projectData = wrapper.saves;

                foreach (SaveData s in projectData.saves)
                {
                    if(s.savepath == deleteT.text)
                    {
                        Debug.Log(s.savepath);                        
                        projectData.saves.Remove(s);

                       wrapper = new Wrapper();
                        wrapper.saves = projectData;
                        contents = JsonUtility.ToJson(wrapper, true);
                        File.WriteAllText(saved, contents);
                        
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

    public void readPath()
    {
        try
        {
            if (File.Exists(saved))
            {
                string contents = System.IO.File.ReadAllText(saved);
                Wrapper wrapper = JsonUtility.FromJson<Wrapper>(contents);
                projectData = wrapper.saves;

                foreach (SaveData s in projectData.saves)
                {
                    string temp = s.savepath;
                    string filename = Path.GetFileName(temp);
                    filename = filename.Remove(filename.Length - 5, 5);

                    go = Instantiate(Prefab, transform);
                    Txtcol = go.GetComponentsInChildren<Text>();

                    saveName = Txtcol[2];
                    hidden = Txtcol[3];
                    saveName.text = filename;
                    hidden.text = temp;

                    //Debug.Log(hidden.text);
                    //Debug.Log(filename.Remove(filename.Length - 5,5));
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
