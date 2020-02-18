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
    public string videoURL;
    public string audioURL;
    public string imageURL;
    public string Text;

    public void create()
    {
        int i = bh.getInput();
        int o = bh.getOutput();

        Debug.Log("I = " + i);
        Debug.Log("O = " + o);

        Debug.Log("before " + j);       
        
        if(j > 0)
        {          
            go = (GameObject)Instantiate(TriggerPrefab, transform);
            Debug.Log("instantiate");
        }

        if (i == 1)
        {
            IName.text = "RFID";
            PlayerPrefs.SetInt("inputType" + j, i);
        }
        else if (i == 2)
        {
            IName.text = "Motion";
            PlayerPrefs.SetInt("inputType" + j, i);
        }
        else
        {
            IName.text = "Touch";
            PlayerPrefs.SetInt("inputType" + j, i);
        }

        if (o == 1)
        {
            OName.text = "Audio";
            OAction.text = "PLAY";
            PlayerPrefs.SetInt("outputType" + j, o);
            PlayerPrefs.SetString("audioURL" + j, audioURL);
            Debug.Log("audio = " + audioURL);
        }
        else if (o == 2)
        {
            OName.text = "Image";
            OAction.text = "DISPLAY";
            PlayerPrefs.SetInt("outputType" + j, o);
            PlayerPrefs.SetString("imageURL" + j, imageURL);
            Debug.Log("image = " + imageURL);
        }
        else if (o == 3)
        {
            OName.text = "Text";
            OAction.text = "DISPLAY";
            PlayerPrefs.SetInt("outputType" + j, o);
            PlayerPrefs.SetString("Text" + j, Text);
            Debug.Log("text = " + Text);

        }
        else
        {
            OName.text = "Video";
            OAction.text = "DISPLAY";
            PlayerPrefs.SetInt("outputType" + j, o);
            PlayerPrefs.SetString("videoURL" + j, videoURL);
            Debug.Log("video = " + videoURL);
        }

        if (j <= 0)
        {
            TriggerPrefab.SetActive(true);
            Debug.Log("unhide");
        }

        
        PlayerPrefs.SetInt("trigger", j);

        ID.text = j.ToString();
        j++;
        Debug.Log("after " + j);
    }

    public void delete(GameObject go)
    {
        if(j != 1)            
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
