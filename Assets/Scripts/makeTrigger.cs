using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeTrigger : MonoBehaviour
{
    public GameObject Sensor;
    public ButtonHighlight bh;    
    public GameObject TriggerPrefab;
    public ProjectData projectData = new ProjectData();
    public GameObject go;
    private Text IName;
    private Text OName;
    private Text OAction;        
    public Text[] Txtcols;
    int j = 0;
    int a = 0;
    public string videoURL;
    public string audioURL;
    public string imageURL;
    public string Text;
    public string RFID;
    public string TOUCH;
    public string MOTION;
    public RegMotion reg;
    public RegTouch touch;
    public RegRFID rfidd;

    public string loadInput;
    public string loadOutput;
    public DataManager dm;
    public bool motionInst = false;

    List<GameObject> objs = new List<GameObject>();

    public void Start()
    {
        if(PlayerPrefs.GetInt("loadStatus") == 1)
        {
            PlayerPrefs.SetInt("loadStatus", 0);
            loadFile(PlayerPrefs.GetString("loadFile"));
        }
    }

    public void create()
    {
        int i = bh.getInput();
        int o = bh.getOutput();
        j++;               

        //increment value of T
        PlayerPrefs.SetInt("T", j);
        Debug.Log("T = " + PlayerPrefs.GetInt("T"));        
        
            go = Instantiate(TriggerPrefab, transform);
            
            Txtcols = go.GetComponentsInChildren<Text>();

            IName = Txtcols[0];
            OName = Txtcols[1];
            OAction = Txtcols[2];
            objs.Add(go);                        
            
            Debug.Log("instantiate");
            Debug.Log(j);

                

        if (i == 1)
        {
            IName.text = "RFID";
            //PlayerPrefs.SetString("T"+ j + "input", IName.text);
            //PlayerPrefs.SetString("card", RFID);
            PlayerPrefs.SetString("sensor" + j, RFID);
            Debug.Log(PlayerPrefs.GetString("sensor" + j));
            rfidd.Start();
            rfidd.card.text = "NULL";
        }
        else if (i == 2)
        {
            IName.text = "Motion";
            //PlayerPrefs.SetString("T" + j + "input", IName.text);
            PlayerPrefs.SetString("sensor" + j, IName.text);
            Debug.Log(PlayerPrefs.GetString("sensor" + j));
            //Sensor.GetComponent<ConnectToServer>().SensorData = "NO MOTION DETECTED";
            reg.status.text = "NO MOTION DETECTED";
            motionInst = true;
             
        }
        else
        {
            IName.text = "Touch";
            //PlayerPrefs.SetString("T" + j + "input", IName.text);
            PlayerPrefs.SetString("sensor" + j, TOUCH);
            Debug.Log(PlayerPrefs.GetString("sensor" + j));
            //Sensor.GetComponent<ConnectToServer>().SensorData = "NO TOUCH DETECTED";
            touch.status.text = "NO TOUCH DETECTED";
        }

        if (o == 1)
        {
            OName.text = "Audio";
            OAction.text = "PLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), audioURL);
            PlayerPrefs.SetString("outputType" + j, OName.text);
            //Debug.Log(PlayerPrefs.GetString("T" + j + "output"));          
           
        }
        else if (o == 2)
        {
            OName.text = "Image";
            OAction.text = "DISPLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);            
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), imageURL);
            PlayerPrefs.SetString("outputType" + j, OName.text);

        }
        else if (o == 3)
        {
            OName.text = "Text";
            OAction.text = "DISPLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);            
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), Text);
            PlayerPrefs.SetString("outputType" + j, OName.text);


        }
        else
        {
            OName.text = "Video";
            OAction.text = "DISPLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);            
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), videoURL);
            PlayerPrefs.SetString("outputType" + j, OName.text);
            Debug.Log("MAKETRIGGER videoURL :" + videoURL);

        }              
               
        Debug.Log("trigger iteration: " + j);
    }     

    public void loadFile(string path)
    {
        dm.loaded = true;

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

                    loadInput = s.input;
                    
                    loadOutput = s.output;
                    

                    if (s.input == "Motion")
                    {
                        if (s.outputType == "Audio")
                        {
                            recreate(2, 1);
                        }
                        else if (s.outputType == "Image")
                        {
                            recreate(2, 2);
                        }
                        else if (s.outputType == "Video")
                        {
                            recreate(2, 3);
                        }
                        else
                        {
                            recreate(2, 4);
                        }
                    }

                    else if (s.input.Contains("Touch"))
                    {
                        if (s.outputType == "Audio")
                        {
                            recreate(3, 1);
                        }
                        else if (s.outputType == "Image")
                        {
                            recreate(3, 2);
                        }
                        else if (s.outputType == "Video")
                        {
                            recreate(3, 3);
                        }
                        else
                        {
                            recreate(3, 4);
                        }
                    }

                    else if (s.input.Contains("Card"))
                    {
                        if (s.outputType == "Audio")
                        {
                            recreate(1, 1);
                        }
                        else if (s.outputType == "Image")
                        {
                            recreate(1, 2);
                        }
                        else if (s.outputType == "Video")
                        {
                            recreate(1, 3);
                        }
                        else
                        {
                            recreate(1, 4);
                        }
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

    public void recreate(int i,int o)
    {
        
        j++;

        //increment value of T
        PlayerPrefs.SetInt("T", j);
        Debug.Log("T = " + PlayerPrefs.GetInt("T"));

        go = Instantiate(TriggerPrefab, transform);

        Txtcols = go.GetComponentsInChildren<Text>();

        IName = Txtcols[0];
        OName = Txtcols[1];
        OAction = Txtcols[2];
        objs.Add(go);

        //Debug.Log("instantiate");
        Debug.Log(j);



        if (i == 1)
        {
            IName.text = "RFID";
            //PlayerPrefs.SetString("T"+ j + "input", IName.text);
            //PlayerPrefs.SetString("card", RFID);
            PlayerPrefs.SetString("sensor" + j, loadInput);
            Debug.Log(PlayerPrefs.GetString("sensor" + j));
            //rfidd.Start();
            //rfidd.card.text = "NULL";
        }
        else if (i == 2)
        {
            IName.text = "Motion";
            //PlayerPrefs.SetString("T" + j + "input", IName.text);
            PlayerPrefs.SetString("sensor" + j, IName.text);
            Debug.Log(PlayerPrefs.GetString("sensor" + j));
            //Sensor.GetComponent<ConnectToServer>().SensorData = "NO MOTION DETECTED";
            //reg.status.text = "NO MOTION DETECTED";
            motionInst = true;
        }
        else
        {
            IName.text = "Touch";
            //PlayerPrefs.SetString("T" + j + "input", IName.text);
            PlayerPrefs.SetString("sensor" + j, loadInput);
            Debug.Log(PlayerPrefs.GetString("sensor" + j));
            //Sensor.GetComponent<ConnectToServer>().SensorData = "NO TOUCH DETECTED";
            //touch.status.text = "NO TOUCH DETECTED";
        }

        if (o == 1)
        {
            OName.text = "Audio";
            OAction.text = "PLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), loadOutput);
            PlayerPrefs.SetString("outputType" + j, OName.text);
            //Debug.Log(PlayerPrefs.GetString("T" + j + "output"));          

        }
        else if (o == 2)
        {
            OName.text = "Image";
            OAction.text = "DISPLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);            
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), loadOutput);
            PlayerPrefs.SetString("outputType" + j, OName.text);

        }
        else if (o == 3)
        {
            OName.text = "Video";
            OAction.text = "DISPLAY";            
            //PlayerPrefs.SetString("T" + j + "output", OName.text);            
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), loadOutput);
            PlayerPrefs.SetString("outputType" + j, OName.text);
            //Debug.Log("MAKETRIGGER videoURL :" + videoURL);


        }
        else
        {
            OName.text = "Text";
            OAction.text = "DISPLAY";
            //PlayerPrefs.SetString("T" + j + "output", OName.text);            
            PlayerPrefs.SetString(PlayerPrefs.GetString("sensor" + j), loadOutput);
            PlayerPrefs.SetString("outputType" + j, OName.text);

        }

        //Debug.Log("trigger iteration: " + j);
    }

    public void deleteSeq()
    {
        a = objs.Count;
        Debug.Log("objs Quantity = " + a);

        if (j > 0 && a != 0)
        {
            Debug.Log("before =" + PlayerPrefs.GetInt("T"));

            

            if(PlayerPrefs.GetString("sensor" + j) == "Motion")
            {
                motionInst = false;
                Debug.Log("motionInst = false");
            }

            PlayerPrefs.DeleteKey("sensor" + j);
            PlayerPrefs.DeleteKey(PlayerPrefs.GetString("sensor" + j));
            PlayerPrefs.DeleteKey("outputType" + j);

            PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T")-1);

            Debug.Log(PlayerPrefs.GetInt("T"));

            GameObject c = objs[a-1];
            Destroy(c);
            objs.Remove(c);
            Debug.Log("destroy");
            j--;
        }

        else
        {
            PlayerPrefs.SetInt("T", 0);

            //PlayerPrefs.DeleteAll();
            int l = PlayerPrefs.GetInt("T");

            if (l > 0)
            {
                j = 0;

                for (int x = 1; x <= l; x++)
                {
                    
                    PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T") - 1);                   

                    PlayerPrefs.DeleteKey("sensor" + x);
                    PlayerPrefs.DeleteKey(PlayerPrefs.GetString("sensor" + x));                   
                    PlayerPrefs.DeleteKey("outputType" + x);                   
                    Debug.Log("deleted " + x + " times");

                }
                Debug.Log("Deleted all");
            }
           
        }
        
            
    }
   
    public void setVideoURL(string s)
    {
        videoURL = s;
        Debug.Log(s);
    }

    public void setAudioURL(string s)
    {
        audioURL = s;
        Debug.Log(s);
    }

    public void setImageURL(string s)
    {
        imageURL = s;
        Debug.Log(s);
    }

    public void setText(string s)
    {
        Text = s;
        Debug.Log(s);
    }

    public void setRFID(string s)
    {
        RFID = s;
        Debug.Log(s);
    }

    public void setTouch(string s)
    {
        TOUCH = s;
        Debug.Log(s);
    }


    public void setMotion(string s)
    {
        MOTION = s;
        Debug.Log(s);
    }


}
