using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoDevManager : MonoBehaviour
{
    public Text projectText;

    public void UpdateName(string Name){
        projectText.text = Name;
    }
}
