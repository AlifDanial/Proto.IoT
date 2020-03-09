using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTouch : MonoBehaviour
{
    public GameObject Sensor;
    public makeTrigger mt;
    public GameObject closeMe;
    public bool Touch = false;
    public Logo logo;

    // Start is called before the first frame update
    void Start()
    {
        Sensor.GetComponent<ConnectToServer>().SensorData = "Empty";
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch == true && Sensor.GetComponent<ConnectToServer>().SensorData == "Touch")
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
        mt.setMotion(touch);
    }
}
