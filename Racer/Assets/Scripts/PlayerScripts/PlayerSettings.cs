using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] Carcontroller car;
    public TMP_InputField[] Data;

    private float brake;
    private float speed;

    private void Start()   // storing default value
    {
        brake = car.breakForce;
        speed = car.straightSpeed;
      
    }

    public void RefreshValue()  // setting value to default
    {
        car.breakForce = brake;
        car.straightSpeed = speed;
        Data[0].text = speed.ToString();
        Data[1].text = brake.ToString();
    }


    public void ChangePower()
    {
        car.straightSpeed = (int.Parse( Data[0].text));  // setting power
    }

    public void ChangeBrake()
    {
        car.breakForce = (int.Parse(Data[1].text));    //setting brake
    }

    public void OpenPanel() // displaying intial values
    {
        Data[0].text = car.straightSpeed.ToString();
        Data[1].text = car.breakForce.ToString();
    }
}
