using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{

   public void PopupOpener(GameObject o)
    {
        o.SetActive(true);
   }

    public void PopupClose(GameObject o)
    {
        o.SetActive(false);
    }
}
