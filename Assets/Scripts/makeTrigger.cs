using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeTrigger : MonoBehaviour
{
    public ButtonHighlight bh;    
    public GameObject TriggerPrefab;
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
    List<GameObject> objs = new List<GameObject>();    

    public void create()
    {
        int i = bh.getInput();
        int o = bh.getOutput();
        j++;               

        //increment value of T
        PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T") + 1);
        Debug.Log(PlayerPrefs.GetInt("T"));
        //set the trigger foreign key        
        PlayerPrefs.SetString("trigger", "T" + PlayerPrefs.GetInt("T"));
        Debug.Log(PlayerPrefs.GetString("trigger"));

        
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
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "input", IName.text);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "input"));
        }
        else if (i == 2)
        {
            IName.text = "Motion";
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "input", IName.text);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "input"));
        }
        else
        {
            IName.text = "Touch";
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "input", IName.text);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "input"));
        }

        if (o == 1)
        {
            OName.text = "Audio";
            OAction.text = "PLAY";
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);            
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));
            
            PlayerPrefs.SetString("audioURL" + j, audioURL);
            Debug.Log(PlayerPrefs.GetString("audioURL" + j));
            Debug.Log("audio = " + audioURL);
        }
        else if (o == 2)
        {
            OName.text = "Image";
            OAction.text = "DISPLAY";            
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);            
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));
            
            PlayerPrefs.SetString("imageURL" + j, imageURL);
            Debug.Log(PlayerPrefs.GetString("imageURL" + j));
            Debug.Log("image = " + imageURL);
        }
        else if (o == 3)
        {
            OName.text = "Text";
            OAction.text = "DISPLAY";
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);            
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));
           
            PlayerPrefs.SetString("Text" + j, Text);
            Debug.Log(PlayerPrefs.GetString("Text" + j));
            Debug.Log("text = " + Text);

        }
        else
        {
            OName.text = "Video";
            OAction.text = "DISPLAY"; 
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);            
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));             
            
            PlayerPrefs.SetString("videoURL" + j, videoURL);
            Debug.Log(PlayerPrefs.GetString("videoURL" + j));
            Debug.Log("video = " + videoURL);
        }              
               
        Debug.Log("after " + j);
    }     

    public void deleteSeq()
    {
        a = objs.Count;
        Debug.Log("objs count = " + a);
        //int b = input.Count;
        //int c = output.Count;

        if (j > 0)
        {
            Debug.Log("before =" + PlayerPrefs.GetInt("T"));
            Debug.Log("input =" + PlayerPrefs.GetString("T" + j + "input"));
            Debug.Log("output =" + PlayerPrefs.GetString("T" + j + "output"));

            PlayerPrefs.DeleteKey("T" + j + "input");
            PlayerPrefs.DeleteKey("T" + j + "output");

            PlayerPrefs.DeleteKey("audioURL" + j + "output");
            PlayerPrefs.DeleteKey("imageURL" + j + "output");
            PlayerPrefs.DeleteKey("Text" + j + "output");
            PlayerPrefs.DeleteKey("videoURL" + j + "output");
            
            PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T")-1);            

            GameObject c = objs[a-1];
            Destroy(c);
            objs.Remove(c);
            Debug.Log("destroy");
            j--;
        }

        else
        {
            PlayerPrefs.DeleteAll();
            int l = PlayerPrefs.GetInt("T");

            if (l > 1)
            {
                j = 1;

                for (int x = 1; x < l; x++)
                {
                    //if(PlayerPrefs.GetInt("T") != 0)
                    //{
                    PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T") - 1);
                    PlayerPrefs.DeleteKey("trigger" + x + "input");
                    PlayerPrefs.DeleteKey("trigger" + x + "output");
                    PlayerPrefs.DeleteKey("audioURL" + x + "output");
                    PlayerPrefs.DeleteKey("imageURL" + x + "output");
                    PlayerPrefs.DeleteKey("Text" + x + "output");
                    PlayerPrefs.DeleteKey("videoURL" + x + "output");
                    Debug.Log("deleted" + x + "times");
                    //}

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

}
