using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSettingPreference : MonoBehaviour
{
    public TMP_InputField[] Data;

    private float brake;
    private float speed;

    private void Start()   // storing default value
    {
        brake = PlayerPrefs.GetInt("Brake");
        speed = PlayerPrefs.GetInt("Speed");

    }

    public void RefreshValue()  // setting value to default
    {
        PlayerPrefs.SetInt("Brake",(int)brake);
        PlayerPrefs.SetInt("Speed", (int)speed);
        Data[0].text = speed.ToString();
        Data[1].text = brake.ToString();
    }


    public void ChangePower()
    {
        PlayerPrefs.SetInt("Speed",int.Parse(Data[0].text));  // setting power
    }

    public void ChangeBrake()
    {
        PlayerPrefs.SetInt("Brake",int.Parse(Data[1].text));    //setting brake
    }

    public void OpenPanel() // displaying intial values
    {
        Data[0].text = PlayerPrefs.GetInt("Speed").ToString();
        Data[1].text = PlayerPrefs.GetInt("Brake").ToString();
    }
}
