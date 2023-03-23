using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Carcontroller : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float rotationAngle;

    [SerializeField] ButtonPress brakeButton;
    [SerializeField] Acelarator acelarator;
    [SerializeField] private bool isbreaking = false;
    [SerializeField] float maxRotationAngle = 20f;
    [SerializeField] float straightSpeed = 1000;
    [SerializeField] float breakForce = 20000;
    [SerializeField] float currentBreakFroce = 0;
    [SerializeField] VirtualDPad Dpad;
    [Space]
    [SerializeField] GameObject joystick;
    [SerializeField] WheelCollider frontLeftColl;
    [SerializeField] WheelCollider frontRightColl;
    [SerializeField] WheelCollider backLeftColl;
    [SerializeField] WheelCollider backRightColl;

    [SerializeField] Transform frontLeftTran;
    [SerializeField] Transform frontRightTran;
    [SerializeField] Transform backLeftTran;
    [SerializeField] Transform backRightTran;



    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        currentBreakFroce = isbreaking ? breakForce : 0f;
        if (!isbreaking)
        {
            HandleMotor();
        }

        ApplyBrake();
        HandleSteering();
        UpdateWheels();
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftColl, frontLeftTran);
        UpdateSingleWheel(frontRightColl, frontRightTran);
        UpdateSingleWheel(backLeftColl, backLeftTran);
        UpdateSingleWheel(backRightColl, backRightTran);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos,out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private void HandleSteering()
    {
        rotationAngle = maxRotationAngle * horizontalInput;
        frontRightColl.steerAngle = rotationAngle;
        frontLeftColl.steerAngle = rotationAngle;
    }

    private void HandleMotor()
    {
        backLeftColl.motorTorque = verticalInput * straightSpeed;
        backRightColl.motorTorque = verticalInput * straightSpeed;
        frontLeftColl.motorTorque = verticalInput * straightSpeed;
        frontRightColl.motorTorque = verticalInput * straightSpeed;
        
    }

    private void ApplyBrake()
    {
        frontLeftColl.brakeTorque = currentBreakFroce;
        frontRightColl.brakeTorque = currentBreakFroce;
        backLeftColl.brakeTorque = currentBreakFroce;
        backRightColl.brakeTorque = currentBreakFroce;
      
    }

    void GetInput()
    {

        //isbreaking = false;
        // horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //isbreaking = Input.GetKey(KeyCode.Space);

        horizontalInput = Dpad.horizontal;
        verticalInput = acelarator.velocity;
        isbreaking = brakeButton.brakeState;

    }

}
