﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;

    public Image img5;
    public Image img6;
    public Image img7;
    public Image img8;
    public Image img9;
    public Image img10;

    public Text txt1;
    public Text txt2;
    public Text txt3;
    public Text txt4;

    public Text txt5;
    public Text txt6;
    public Text txt7;
    public Text txt8;
    public Text txt9;
    public Text txt10;

    public Text status;
    public Text status1;
    public Text READY;
    public Text NOTREADY;
    public Text READY1;
    public Text NOTREADY1;

    public bool input = false;
    public bool output = false;




    void Start()
    {
        img1.enabled = false;
        img2.enabled = false;
        img3.enabled = false;
        img4.enabled = false;

        img5.enabled = false;
        img6.enabled = false;
        img7.enabled = false;
        img8.enabled = false;
        img9.enabled = false;
        img10.enabled = false;

        txt1.enabled = false;
        txt2.enabled = false;
        txt3.enabled = false;
        txt4.enabled = false;
        txt5.enabled = false;
        txt6.enabled = false;
        txt7.enabled = false;
        txt8.enabled = false;
        txt9.enabled = false;
        txt10.enabled = false;

        status.enabled = false;
        status1.enabled = false;
        READY.enabled = false;
        NOTREADY.enabled = false;
        READY1.enabled = false;
        NOTREADY1.enabled = false;


    }


    public void ImageHolder(int i)
    {
        if (i == 1)
        {
            img1.enabled = true;
            img2.enabled = false;
            img3.enabled = false;
            img4.enabled = false;

            status.enabled = true;
            NOTREADY.enabled = true;
            READY.enabled = false;
        }
        if (i == 2)
        {
            img1.enabled = false;
            img2.enabled = true;
            img3.enabled = false;
            img4.enabled = false;

            status.enabled = true;
            NOTREADY.enabled = true;
            READY.enabled = false;
        }
        if (i == 3)
        {
            img1.enabled = false;
            img2.enabled = false;
            img3.enabled = true;
            img4.enabled = false;

            status.enabled = true;
            NOTREADY.enabled = true;
            READY.enabled = false;
        }
        if (i == 4)
        {
            img1.enabled = false;
            img2.enabled = false;
            img3.enabled = false;
            img4.enabled = true;

            status.enabled = true;
            NOTREADY.enabled = true;
            READY.enabled = false;

        }
        if (i == 5)
        {
            img5.enabled = true;
            img6.enabled = false;
            img7.enabled = false;
            img8.enabled = false;
            img9.enabled = false;
            img10.enabled = false;

            status1.enabled = true;
            NOTREADY1.enabled = true;
            READY1.enabled = false;


        }
        if (i == 6)
        {
            img5.enabled = false;
            img6.enabled = true;
            img7.enabled = false;
            img8.enabled = false;
            img9.enabled = false;
            img10.enabled = false;

            status1.enabled = true;
            NOTREADY1.enabled = true;
            READY1.enabled = false;
        }
        if (i == 7)
        {
            img5.enabled = false;
            img6.enabled = false;
            img7.enabled = true;
            img8.enabled = false;
            img9.enabled = false;
            img10.enabled = false;

            status1.enabled = true;
            NOTREADY1.enabled = true;
            READY1.enabled = false;
        }
        if (i == 8)
        {
            img5.enabled = false;
            img6.enabled = false;
            img7.enabled = false;
            img8.enabled = true;
            img9.enabled = false;
            img10.enabled = false;

            status1.enabled = true;
            NOTREADY1.enabled = true;
            READY1.enabled = false;
        }
        if (i == 9)
        {
            img5.enabled = false;
            img6.enabled = false;
            img7.enabled = false;
            img8.enabled = false;
            img9.enabled = true;
            img10.enabled = false;

            status1.enabled = true;
            NOTREADY1.enabled = true;
            READY1.enabled = false;
        }
        if (i == 10)
        {
            img5.enabled = false;
            img6.enabled = false;
            img7.enabled = false;
            img8.enabled = false;
            img9.enabled = false;
            img10.enabled = true;

            status1.enabled = true;
            NOTREADY1.enabled = true;
            READY1.enabled = false;
        }
    }


    public void TextHolder(int i)
    {
        if (i == 1)
        {
            txt1.enabled = true;
            txt2.enabled = false;
            txt3.enabled = false;
            txt4.enabled = false;
        }
        if (i == 2)
        {
            txt1.enabled = false;
            txt2.enabled = true;
            txt3.enabled = false;
            txt4.enabled = false;
        }
        if (i == 3)
        {
            txt1.enabled = false;
            txt2.enabled = false;
            txt3.enabled = true;
            txt4.enabled = false;
        }
        if (i == 4)
        {
            txt1.enabled = false;
            txt2.enabled = false;
            txt3.enabled = false;
            txt4.enabled = true;
        }
        if (i == 5)
        {
            txt5.enabled = true;
            txt6.enabled = false;
            txt7.enabled = false;
            txt8.enabled = false;
            txt9.enabled = false;
            txt10.enabled = false;
        }
        if (i == 6)
        {
            txt5.enabled = false;
            txt6.enabled = true;
            txt7.enabled = false;
            txt8.enabled = false;
            txt9.enabled = false;
            txt10.enabled = false;
        }
        if (i == 7)
        {
            txt5.enabled = false;
            txt6.enabled = false;
            txt7.enabled = true;
            txt8.enabled = false;
            txt9.enabled = false;
            txt10.enabled = false;
        }
        if (i == 8)
        {
            txt5.enabled = false;
            txt6.enabled = false;
            txt7.enabled = false;
            txt8.enabled = true;
            txt9.enabled = false;
            txt10.enabled = false;
        }
        if (i == 9)
        {
            txt5.enabled = false;
            txt6.enabled = false;
            txt7.enabled = false;
            txt8.enabled = false;
            txt9.enabled = true;
            txt10.enabled = false;
        }
        if (i == 10)
        {
            txt5.enabled = false;
            txt6.enabled = false;
            txt7.enabled = false;
            txt8.enabled = false;
            txt9.enabled = false;
            txt10.enabled = true;
        }
    }

    public void OutputReady()
    {
        NOTREADY1.enabled = false;
        READY1.enabled = true;
    }

    public void InputReady() 
    {
        NOTREADY.enabled = false;
        READY.enabled = true;
    }

    public bool InputGetStatus()
    {
        if (READY.enabled == true)
        {
            input = true;
            return input;
        }
        else 
        {
            input = false;
            return input;
        }
            
    }

    public bool OutputGetStatus()
    {
        if (READY1.enabled == true)
        {
            input = true;
            return input;
        }
        else
        {
            input = false;
            return input;
        }

    }

    public void setInputFalse()
    {
        READY.enabled = false;
        NOTREADY.enabled = true;
    }

    public void setOutputFalse()
    {
        READY1.enabled = false;
        NOTREADY1.enabled = true;
    }


}
        

       

