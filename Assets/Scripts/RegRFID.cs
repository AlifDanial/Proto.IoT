using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegRFID : MonoBehaviour
{

    public GameObject Sensor;
    public makeTrigger mt;
    public GameObject closeMe;
    public Text card;
    public bool RFID = false;
    public Logo logo;

    // Start is called before the first frame update
    public void Start()
    {
        Sensor.GetComponent<ConnectToServer>().SensorData = "NULL";
    }

    // Update is called once per frame
    void Update()
    {
        if(Sensor.GetComponent<ConnectToServer>().SensorData != "NULL" && Sensor.GetComponent<ConnectToServer>().SensorData.Contains("Card"))
        {
            card.text = Sensor.GetComponent<ConnectToServer>().SensorData;
        }        

        if (RFID == true && Sensor.GetComponent<ConnectToServer>().SensorData != "NULL" && Sensor.GetComponent<ConnectToServer>().SensorData != "Motion" && !Sensor.GetComponent<ConnectToServer>().SensorData.Contains("Touch"))
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
        string rfid = Sensor.GetComponent<ConnectToServer>().SensorData;
        mt.setRFID(rfid);        
    }
}
