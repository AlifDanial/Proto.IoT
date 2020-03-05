using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class ConnectToServer : MonoBehaviour {

    // Use this for initialization

    private SocketIOComponent socket;
   
    public string User,Device;
    public string SensorData;
    void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("PostCreatedEvent", OnDemodata);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDemodata(SocketIOEvent e)
    {
        DemoData ch = JsonUtility.FromJson<DemoData>(e.data.ToString());
        SensorData = ch.SensorData.ToString();
        Device = ch.id.ToString();
        Debug.Log(ch.SensorData.ToString());
        Debug.Log(ch.id.ToString());
    }


    }
