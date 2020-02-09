using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeTrigger : MonoBehaviour
{
    public ButtonHighlight bh;

    public GameObject TriggerPrefab;
    [SerializeField] private Text IName;
    [SerializeField] private Text OName;
    [SerializeField] private Text OAction;
    int j = 0;


    public void create()
    {
        int i = bh.getInput();
        int o = bh.getOutput();

        Debug.Log("I = " + i);
        Debug.Log("O = " + o);

        Debug.Log("before " + j);       
        
        if(j > 0)
        {          
            GameObject go = (GameObject)Instantiate(TriggerPrefab, transform);
            Debug.Log("instantiate");
        }

        if (i == 1)
        {
            IName.text = "RFID";
        }
        else if (i == 2)
        {
            IName.text = "Motion";
        }
        else
        {
            IName.text = "Touch";
        }

        if (o == 1)
        {
            OName.text = "Audio";
            OAction.text = "PLAY";
        }
        else if (o == 2)
        {
            OName.text = "Image";
            OAction.text = "DISPLAY";
        }
        else if (o == 3)
        {
            OName.text = "Text";
            OAction.text = "DISPLAY";
        }
        else
        {
            OName.text = "Video";
            OAction.text = "DISPLAY";
        }

        if (j <= 0)
        {
            TriggerPrefab.SetActive(true);
            Debug.Log("unhide");
        }
        

        j++;
        Debug.Log("after " + j);
    }

}
