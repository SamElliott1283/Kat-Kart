using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Axle class defining
[System.Serializable]
public class Axle
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class Controller : MonoBehaviour
{
    public List<Axle> axles;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public bool frozen = false;

    //Constantly happening events like physics & imput
    public void FixedUpdate()
    {
        //Get input on where/how to move
        float motor = 0;
        float steering = 0;

        if (!frozen)
        {
            motor = maxMotorTorque * Input.GetAxis("Vertical");
            steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        }
        
        //Change wheel physics depending on parameters
        foreach (Axle axle in axles)
        {
            if (axle.motor)
            {
                axle.leftWheel.motorTorque = motor;
                axle.rightWheel.motorTorque = motor;
            }
            if (axle.steering)
            {
                axle.leftWheel.steerAngle = steering;
                axle.rightWheel.steerAngle = steering;
            }
        }
    }

    public void Unfreeze()
    {
        frozen = false;
    }
    public void Freeze()
    {
        frozen = true;
    }
}
