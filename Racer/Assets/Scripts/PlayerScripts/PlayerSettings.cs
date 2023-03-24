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

    private void Start()
    {
        brake = car.breakForce;
        speed = car.straightSpeed;
      
    }

    public void RefreshValue() {
        car.breakForce = brake;
        car.straightSpeed = speed;
        Data[0].text = speed.ToString();
        Data[1].text = brake.ToString();
    }


    public void ChangePower()
    {
        car.straightSpeed = (int.Parse( Data[0].text));
    }

    public void ChangeBrake()
    {
        car.breakForce = (int.Parse(Data[1].text));
    }

    public void OpenPanel()
    {
        Data[0].text = car.straightSpeed.ToString();
        Data[1].text = car.breakForce.ToString();
    }
}
