using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegMotion : MonoBehaviour
{
    public GameObject Sensor;
    public makeTrigger mt;
    public GameObject closeMe;
    public bool Motion = false;
    public Logo logo;
    public Text status;

    // Start is called before the first frame update
    void Start()
    {
        Sensor.GetComponent<ConnectToServer>().SensorData = "NO MOTION DETECTED";
    }

    // Update is called once per frame
    void Update()
    {
        if (Sensor.GetComponent<ConnectToServer>().SensorData == "Motion")
        {
            status.text = "MOTION DETECTED";
        }
            

        if (Motion == true && Sensor.GetComponent<ConnectToServer>().SensorData == "Motion")
        {
            Debug.Log("detected");
            Debug.Log(Sensor.GetComponent<ConnectToServer>().SensorData);
            execute();
            Motion = false;
        }
    }

    public void RegsMotion()
    {
        Motion = true;
    }

    public void close(GameObject c)
    {
        c.SetActive(false);
    }

    public void execute()
    {
        close(closeMe);
        logo.InputReady();
        string motion = Sensor.GetComponent<ConnectToServer>().SensorData;
        mt.setMotion(motion);
    }
   
}
