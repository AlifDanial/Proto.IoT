using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour { 

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    public Button btn5;
    public Button btn6;
    public Button btn7;
    public Button btn8;
    public Button btn9;
    public Button btn10;

    public GameObject RFID;   
    public GameObject MOTION;
    public GameObject TOUCH;
    public GameObject SOUND;

    public GameObject AUDIO;
    public GameObject LED;
    public GameObject TEXT;
    public GameObject MOTOR;
    public GameObject VIDEO;
    public GameObject GRAPHICS;

    void Start()
    {
        InitializeColors(btn1);
        InitializeColors(btn2);
        InitializeColors(btn3);
        InitializeColors(btn4);

        InitializeColors2(btn5);
        InitializeColors2(btn6);
        InitializeColors2(btn7);
        InitializeColors2(btn8);
        InitializeColors2(btn9);
        InitializeColors2(btn10);

        InitializeGO(RFID);        
        InitializeGO(TOUCH);
        InitializeGO(MOTION);
        InitializeGO(SOUND);

        InitializeGO(AUDIO);
        InitializeGO(LED);
        InitializeGO(TEXT);
        InitializeGO(MOTOR);
        InitializeGO(VIDEO);
        InitializeGO(GRAPHICS);
    }

    

    public void InitializeColors(Button b)
    {
        ColorBlock colors = b.colors;        
        colors.highlightedColor = new Color32(185, 191, 230, 255);
        b.colors = colors;
    }
    public void InitializeColors2(Button b)
    {
        ColorBlock colors = b.colors;        
        colors.highlightedColor = new Color32(225, 165, 138, 255);
        b.colors = colors;
    }
    public void InitializeGO(GameObject GO)
    {
        GO.SetActive(false);
    }
    public void HighlightButton(Button b)
    {        
        ColorBlock colors = b.colors;
        colors.normalColor = new Color32(185, 191, 230, 255);        
        b.colors = colors;        

    }

    public void HighlightButtonLeft(Button b)
    {
        ColorBlock colors = b.colors;
        colors.normalColor = new Color32(225, 165, 138, 255);        
        b.colors = colors;

    }

    public void DeactivateButton(Button b)
    {
        ColorBlock colors = b.colors;        
        colors.normalColor = Color.white;         
        b.colors = colors;
        
    }

    public void DeactivateButton1(Button b)
    {
        ColorBlock colors = b.colors;        
        colors.normalColor = Color.white;
        b.colors = colors;

    }

    public void ButtonHandler(int i)
    {        
        if (i == 1)
        {
            HighlightButton(btn1);
            DeactivateButton(btn2);
            DeactivateButton(btn3);
            DeactivateButton(btn4);
            RFID.SetActive(true);
            InitializeGO(MOTION);
            InitializeGO(TOUCH);
            InitializeGO(SOUND);
        }
        if (i == 2)
        {
            HighlightButton(btn2);
            DeactivateButton(btn1);
            DeactivateButton(btn3);
            DeactivateButton(btn4);
            MOTION.SetActive(true);
            InitializeGO(RFID);
            InitializeGO(TOUCH);
            InitializeGO(SOUND);
        }
        if (i == 3)
        {
            HighlightButton(btn3);
            DeactivateButton(btn1);
            DeactivateButton(btn2);
            DeactivateButton(btn4);
            TOUCH.SetActive(true);
            InitializeGO(MOTION);
            InitializeGO(RFID);
            InitializeGO(SOUND);
        }
        if (i == 4)
        {
            HighlightButton(btn4);
            DeactivateButton(btn1);
            DeactivateButton(btn2);
            DeactivateButton(btn3);
            SOUND.SetActive(true);
            InitializeGO(MOTION);
            InitializeGO(TOUCH);
            InitializeGO(RFID);
        }

    }
        public void ButtonHandler2(int i)
        {        
        if (i == 5)
        {
            HighlightButtonLeft(btn5);
            DeactivateButton1(btn6);
            DeactivateButton1(btn7);
            DeactivateButton1(btn8);
            DeactivateButton1(btn9);
            DeactivateButton1(btn10);
            AUDIO.SetActive(true);
            InitializeGO(LED);
            InitializeGO(TEXT);
            InitializeGO(MOTOR);
            InitializeGO(VIDEO);
            InitializeGO(GRAPHICS);
        }
        if (i == 6)
        {
            HighlightButtonLeft(btn6);
            DeactivateButton1(btn5);
            DeactivateButton1(btn7);
            DeactivateButton1(btn8);
            DeactivateButton1(btn9);
            DeactivateButton1(btn10);
            LED.SetActive(true);
            InitializeGO(AUDIO);
            InitializeGO(TEXT);
            InitializeGO(MOTOR);
            InitializeGO(VIDEO);
            InitializeGO(GRAPHICS);
        }
        if (i == 7)
        {
            HighlightButtonLeft(btn7);
            DeactivateButton1(btn6);
            DeactivateButton1(btn5);
            DeactivateButton1(btn8);
            DeactivateButton1(btn9);
            DeactivateButton1(btn10);
            TEXT.SetActive(true);
            InitializeGO(LED);
            InitializeGO(AUDIO);
            InitializeGO(MOTOR);
            InitializeGO(VIDEO);
            InitializeGO(GRAPHICS);
        }
        if (i == 8)
        {
            HighlightButtonLeft(btn8);
            DeactivateButton1(btn6);
            DeactivateButton1(btn7);
            DeactivateButton1(btn5);
            DeactivateButton1(btn9);
            DeactivateButton1(btn10);
            MOTOR.SetActive(true);
            InitializeGO(LED);
            InitializeGO(TEXT);
            InitializeGO(AUDIO);
            InitializeGO(VIDEO);
            InitializeGO(GRAPHICS);
        }
        if (i == 9)
        {
            HighlightButtonLeft(btn9);
            DeactivateButton1(btn6);
            DeactivateButton1(btn7);
            DeactivateButton1(btn8);
            DeactivateButton1(btn5);
            DeactivateButton1(btn10);
            VIDEO.SetActive(true);
            InitializeGO(LED);
            InitializeGO(TEXT);
            InitializeGO(MOTOR);
            InitializeGO(AUDIO);
            InitializeGO(GRAPHICS);
        }
        if (i == 10)
        {
            HighlightButtonLeft(btn10);
            DeactivateButton1(btn6);
            DeactivateButton1(btn7);
            DeactivateButton1(btn8);
            DeactivateButton1(btn9);
            DeactivateButton1(btn5);
            GRAPHICS.SetActive(true);
            InitializeGO(LED);
            InitializeGO(TEXT);
            InitializeGO(MOTOR);
            InitializeGO(VIDEO);
            InitializeGO(AUDIO);
        }

    }



}