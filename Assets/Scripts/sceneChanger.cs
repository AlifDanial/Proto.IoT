using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{

    //method to change scene
    public void ChangeToScene(string sceneToChangeTo){
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
