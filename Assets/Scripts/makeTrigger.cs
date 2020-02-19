using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeTrigger : MonoBehaviour
{
    public ButtonHighlight bh;    
    public GameObject TriggerPrefab;
    GameObject go;
    [SerializeField] private Text IName;
    [SerializeField] private Text OName;
    [SerializeField] private Text OAction;
    [SerializeField] private Text ID;
    int j = 0;
    int a = 0;
    public string videoURL;
    public string audioURL;
    public string imageURL;
    public string Text;
    List<GameObject> objs = new List<GameObject>();
    List<int> input = new List<int>();
    List<int> output = new List<int>();

    public void create()
    {
        int i = bh.getInput();
        int o = bh.getOutput();

        //Debug.Log("I = " + i);
        //Debug.Log("O = " + o);

        //Debug.Log("before " + j);

        //increment value of T
        PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T") + 1);
        Debug.Log(PlayerPrefs.GetInt("T"));
        //set the trigger foreign key        
        PlayerPrefs.SetString("trigger", "T" + PlayerPrefs.GetInt("T"));
        Debug.Log(PlayerPrefs.GetString("trigger"));

        if (j > 0)
        {          
            go = (GameObject)Instantiate(TriggerPrefab, transform);
            objs.Add(go);
            //input.Add(i);
            //output.Add(o);
            Debug.Log("instantiate");
        }

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
            Debug.Log("audio = " + audioURL);
        }
        else if (o == 2)
        {
            OName.text = "Image";
            OAction.text = "DISPLAY";            
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));
            PlayerPrefs.SetString("imageURL" + j, imageURL);
            Debug.Log("image = " + imageURL);
        }
        else if (o == 3)
        {
            OName.text = "Text";
            OAction.text = "DISPLAY";
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));
            PlayerPrefs.SetString("Text" + j, Text);
            Debug.Log("text = " + Text);

        }
        else
        {
            OName.text = "Video";
            OAction.text = "DISPLAY"; 
            PlayerPrefs.SetString(PlayerPrefs.GetString("trigger") + "output", OName.text);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefs.GetString("trigger") + "output"));             
            PlayerPrefs.SetString("videoURL" + j, videoURL);
            Debug.Log("video = " + videoURL);
        }

        if (j <= 0)
        {
            TriggerPrefab.SetActive(true);
            Debug.Log("unhide");
        }        

        j++;
        ID.text = j.ToString();

        Debug.Log("after " + j);
    }

    public void delete(GameObject go)
    {
        if(j != 1)            
        {
            PlayerPrefs.SetInt("trigger", j);
            int x = PlayerPrefs.GetInt("inputType" + j);
            Debug.Log("delete " + x + " : index " + j);

            if (x == 1)
            {
                //PlayerPrefs.DeleteKey();
            }
            else if (x == 2)
            {
                //PlayerPrefs.DeleteKey();
            }
            else
            {
                //PlayerPrefs.DeleteKey();
            }
            
            int y = PlayerPrefs.GetInt("outputType" + j);
            Debug.Log("delete " + y + " : index " + j);

            if (y == 1)
            {
                PlayerPrefs.DeleteKey("audioURL" + j);
            }
            else if (y == 2)
            {
                PlayerPrefs.DeleteKey("imageURL" + j);
            }
            else if (y == 3)
            {
                PlayerPrefs.DeleteKey("Text" + j);
            }
            else
            {
                PlayerPrefs.DeleteKey("videoURL" + j);
            }

            Destroy(go);
            Debug.Log("destroy");            
            j--;
        }
        else
        {

             int x = PlayerPrefs.GetInt("inputType" + j);
            Debug.Log("delete " + x + " : index " + j);

            if (x == 1)
            {
                //PlayerPrefs.DeleteKey();
            }
            else if (x == 2)
            {
                //PlayerPrefs.DeleteKey();
            }
            else
            {
                //PlayerPrefs.DeleteKey();
            }
            
            int y = PlayerPrefs.GetInt("outputType" + j);
            Debug.Log("delete " + y + " : index " + j);

            if (y == 1)
            {
                PlayerPrefs.DeleteKey("audioURL" + j);
            }
            else if (y == 2)
            {
                PlayerPrefs.DeleteKey("imageURL" + j);
            }
            else if (y == 3)
            {
                PlayerPrefs.DeleteKey("Text" + j);
            }
            else
            {
                PlayerPrefs.DeleteKey("videoURL" + j);
            }

            TriggerPrefab.SetActive(false);
            Debug.Log("hide");
            j = 0;
        }
    }

    public void resetAll()
    {
        int h;
        for (h = j; h == 0; h--)
        {
            if (j != 1)
            {
                Destroy(go);
                Debug.Log("destroy");
                j--;
            }
            else
            {
                TriggerPrefab.SetActive(false);
                Debug.Log("hide");
                j = 0;
            }
        }
       
        PlayerPrefs.DeleteAll();
    }

    public void deleteSeq()
    {
        a = objs.Count;
        Debug.Log(a);
        //int b = input.Count;
        //int c = output.Count;

        if (j != 1 && j != 0)
        {
            Debug.Log(PlayerPrefs.GetInt("T"));
            Debug.Log(PlayerPrefs.GetString("T" + j + "input"));
            Debug.Log(PlayerPrefs.GetString("T" + j + "output"));
            PlayerPrefs.DeleteKey("trigger" + j + "input");
            PlayerPrefs.DeleteKey("trigger" + j + "output");

            Debug.Log(PlayerPrefs.GetInt("T"));
            Debug.Log(PlayerPrefs.GetString("T" + j + "input"));
            Debug.Log(PlayerPrefs.GetString("T" + j + "output"));

            PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T")-1);


            //PlayerPrefs.DeleteKey();

            GameObject c = objs[a-1];
            Destroy(c);
            Debug.Log("destroy");
            objs.Remove(c);
            j--;
        }
        else
        {
            TriggerPrefab.SetActive(false);
            Debug.Log("hide");
            j = 0;
            Debug.Log(PlayerPrefs.GetInt("T"));
            Debug.Log(PlayerPrefs.GetString("T" + "1" + "input"));
            Debug.Log(PlayerPrefs.GetString("T" + "1" + "output"));
            PlayerPrefs.DeleteKey("trigger" + "1" + "input");
            PlayerPrefs.DeleteKey("trigger" + "1" + "output");
            PlayerPrefs.SetInt("T", PlayerPrefs.GetInt("T") - 1);
            Debug.Log(PlayerPrefs.GetInt("T"));
            Debug.Log(PlayerPrefs.GetString("T" + "1" + "input"));
            Debug.Log(PlayerPrefs.GetString("T" + "1" + "output"));
            PlayerPrefs.DeleteAll();
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
