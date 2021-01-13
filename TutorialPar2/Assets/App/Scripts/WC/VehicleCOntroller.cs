using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCOntroller : MonoBehaviour
{
    public Rigidbody rb;
   
    [Header("Controls")] 
    public float Accel;
    public float Brake;
    public float Steering;
    
    [Header("Vehicle Settings")]
    public float EnginePower = 250f;
    public float BrakeForce = 15000f;
    public float SteerAngle = 35f;
    
    [Header("Wheels")]
    public WheelCollider[] FrontWheels;
    public WheelCollider[] RearWheels;

    
    [SerializeField] public GameObject CenterOfMass;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass =CenterOfMass.transform.position;
    }

    private void Update()
    {
        Accel = Input.GetAxis("Vertical");
        Brake = Input.GetAxis("Jump");
        Steering = Input.GetAxis("Horizontal"); 
        WheelbrakeTorque();
        WheelsteerAngle();
        WheelMotorTorque();
        
        
    }
    private void  WheelMotorTorque()
    {
        
        foreach (WheelCollider wheel in FrontWheels)
        {
            wheel.motorTorque = EnginePower * Accel;
        }
        foreach (WheelCollider wheel in RearWheels)
        {
            wheel.motorTorque = EnginePower * Accel;
        }
    }
    private void  WheelbrakeTorque()
    {
        
        foreach (WheelCollider wheel in FrontWheels)
        {
            wheel.brakeTorque = BrakeForce * Brake;
        }
        foreach (WheelCollider wheel in RearWheels)
        {
            wheel.brakeTorque = BrakeForce * Brake;
        }
    }
    private void  WheelsteerAngle()
    {
        foreach (WheelCollider wheel in FrontWheels)
        {
            wheel.steerAngle = SteerAngle * Steering;
        }
        
        
    }
    

}
