using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class KeyBoardControl : MonoBehaviour {
    [DllImport("user32.dll", EntryPoint = "keybd_event")]

    
    public static extern void Keybd_event(byte bvk, byte bScan, int dwFlags, int dwExtraInfo);
    public string pin0,pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10,pin11;
    
  

    void Start() {

       
    }

    // Update is called once per frame
    void Update() {


        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "0" )
        {
            ConvertByte(pin0);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "1")
        {
            ConvertByte(pin1);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "2")
        {
            ConvertByte(pin2);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "3")
        {
            ConvertByte(pin3);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "4")
        {
            ConvertByte(pin4);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "5")
        {
            ConvertByte(pin5);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "6")
        {
            ConvertByte(pin6);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "7")
        {
            ConvertByte(pin7);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "8")
        {
            ConvertByte(pin8);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "9")
        {
            ConvertByte(pin9);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "10")
        {
            ConvertByte(pin10);
        }
        if (gameObject.GetComponent<KeyBoardSocketService>().SensorData == "11")
        {
            ConvertByte(pin11);
        }
    }

    public void ConvertByte(string pin)
    {
        string str1 = pin;
        byte[] array = System.Text.Encoding.ASCII.GetBytes(str1);
        byte newPin = Convert.ToByte(array[0]);
    
        Keybd_event(newPin, 0, 0, 0);
        Keybd_event(newPin, 0, 1, 0);
        Keybd_event(newPin, 0, 2, 0);

     
    }



}
