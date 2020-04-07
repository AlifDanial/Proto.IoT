using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegTouch : MonoBehaviour
{
    public GameObject Sensor;
    public makeTrigger mt;
    public GameObject closeMe;
    public bool Touch = false;
    public Logo logo;
    public Text status;

    // Start is called before the first frame update
    void Start()
    {
        Sensor.GetComponent<ConnectToServer>().SensorData = "NO TOUCH DETECTED";
    }

    // Update is called once per frame
    void Update()
    {

        if (Sensor.GetComponent<ConnectToServer>().SensorData.Contains("Touch"))
        {
            string temp = Sensor.GetComponent<ConnectToServer>().SensorData;
            string pass = temp.Substring(5,2);
            status.text = "PIN " + pass + " DETECTED"; 
        }

        if (Touch == true && Sensor.GetComponent<ConnectToServer>().SensorData.Contains("Touch"))
        {
            Debug.Log("detected");
            Debug.Log(Sensor.GetComponent<ConnectToServer>().SensorData);
            execute();
            Touch = false;
        }
    }

    public void RegsTouch()
    {
        Touch = true;
    }

    public void close(GameObject c)
    {
        c.SetActive(false);
    }

    public void execute()
    {
        close(closeMe);
        logo.InputReady();
        string touch = Sensor.GetComponent<ConnectToServer>().SensorData;
        //string t = touch.Substring(6, 7);
        mt.setTouch(touch);
    }
}
