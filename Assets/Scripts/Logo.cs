using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;


    void Start()
    {
        img1.enabled = false;
        img2.enabled = false;
        img3.enabled = false;
        img4.enabled = false;
    }

    void Update()
    {
            
            if (Button.GetLogo() == 1)
            {

                if (img1.enabled == false)
                {

                    img1.enabled = true;                    
                    img2.enabled = false;                    
                    img3.enabled = false;                    
                    img4.enabled = false;                    
                }

                else
                {

                    img1.enabled = false;
                }
            }
            if (Button.GetLogo() == 2)
            {

                if (img2.enabled == false)
                {
                img1.enabled = false;
                img2.enabled = true;
                img3.enabled = false;
                img4.enabled = false;
            }

                else
                {

                    img2.enabled = false;
                }
            }
            if (Button.GetLogo() == 3)
            {

                if (img3.enabled == false)
                {

                img1.enabled = false;
                img2.enabled = false;
                img3.enabled = true;
                img4.enabled = false;
            }

                else
                {

                    img3.enabled = false;
                }
            }
            if (Button.GetLogo() == 4)
            {

                if (img4.enabled == false)
                {

                img1.enabled = false;
                img2.enabled = false;
                img3.enabled = false;
                img4.enabled = true;
            }

                else
                {

                    img4.enabled = false;
                }
            }
        }
    }

       

