using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegRFID : MonoBehaviour
{

    public GameObject Sensor;
    public GameObject closeMe;
    public bool RFID = false;
    public Logo logo;

    // Start is called before the first frame update
    void Start()
    {
        Sensor.GetComponent<ConnectToServer>().SensorData = "Empty";
    }

    // Update is called once per frame
    void Update()
    {
        if (RFID == true && Sensor.GetComponent<ConnectToServer>().SensorData != "Empty")
        {
            Debug.Log("detected");
            Debug.Log(Sensor.GetComponent<ConnectToServer>().SensorData);
            execute();
            RFID = false;
        }
    }

    public void RegsRFID()
    {
        RFID = true;
    }

    public void close(GameObject c)
    {
        c.SetActive(false);
    }

    public void execute()
    {
        close(closeMe);
        logo.InputReady();
    }
}
