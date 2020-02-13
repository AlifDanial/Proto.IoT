using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveChangesButton : MonoBehaviour
{
    public Logo logo;
    public makeTrigger mt;
    
    public Button b;
    public Sprite spr1;
    public Sprite spr2;
    
    
    bool clickable = false;

    // Update is called once per frame
    void Update()
    {
        if (logo.InputGetStatus() && logo.OutputGetStatus())
        {
            HighlightButton();
            clickable = true;
        }
        else
        {
            UnhighlightButton();
            clickable = false;
        }
            
    }

    public void HighlightButton()
    {
        b.GetComponent<Image>().sprite = spr1;
        b.interactable = true;
    }

    public void UnhighlightButton()
    {
        b.GetComponent<Image>().sprite = spr2;
        b.interactable = false;
    }

    public void display()
    {
        if(clickable == true)
        {
            mt.create();
            clickable = false;
            logo.setInputFalse();
            logo.setOutputFalse();
        }
        
    }


}
