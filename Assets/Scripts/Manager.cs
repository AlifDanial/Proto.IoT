using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
   private void Awake()
{
    //  image = GetComponent<UnityEngine.UI.Image>();

     HideImage();
}

public void HideImage()
{
    //  image.enabled = false ;

     // ===== OR =====

     gameObject.SetActive(false);
}





}
