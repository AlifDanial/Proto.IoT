using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static int Logo;

    
        public void SetLogo(int logo)
        {
            if (logo == 1)
            {            
            Logo = 1;            
            }
            if (logo == 2)
            {            
            Logo = 2;
            }
            if (logo == 3)
            {            
            Logo = 3;           
            }
            if (logo == 4)
            {           
            Logo = 4;            
            }            
        }

    public static int GetLogo()
    {
        return Logo;        
    }
 }
    

