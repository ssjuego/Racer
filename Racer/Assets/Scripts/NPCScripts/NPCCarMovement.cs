using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarMovement : MonoBehaviour
{
    private float verticalInput = 1f;
    
    [SerializeField] float straightSpeed = 5000;
    [SerializeField] float maxSpeed = 15;
    [SerializeField] Rigidbody rb;
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
        if(rb.velocity.z < maxSpeed)
              HandleMotor();
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
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    

    private void HandleMotor()
    {
        backLeftColl.motorTorque = verticalInput * straightSpeed;
        backRightColl.motorTorque = verticalInput * straightSpeed;
        frontLeftColl.motorTorque = verticalInput * straightSpeed;
        frontRightColl.motorTorque = verticalInput * straightSpeed;
    }

   
}
