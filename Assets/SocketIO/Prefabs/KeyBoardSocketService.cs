using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class KeyBoardSocketService : MonoBehaviour {

    private SocketIOComponent socket;
    public string Device,SensorData;
    // Use this for initialization

    void Start () {
        socket = gameObject.GetComponent<SocketIOComponent>();
        socket.On("PostCreatedEvent", OnKeyboarddata);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnKeyboarddata(SocketIOEvent e)
    {
        DemoData ch = JsonUtility.FromJson<DemoData>(e.data.ToString());
        SensorData = ch.SensorData.ToString();
        Device = ch.id.ToString();
       
    }
}
