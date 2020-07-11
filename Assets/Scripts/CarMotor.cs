using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Basic ass controller for a car stolen from an Official Unity Tutorial */
public class CarMotor : MonoBehaviour
{
    public List<AxleInfo> axles;
    public float maxTorque;
    public float maxSteeringAngle;
    // Start is called before the first frame update

    float amountOfMotor;
    float amountOfSteering;

    public void setMotor(float motorAmount){
        amountOfMotor = maxTorque * motorAmount;
    }

    public void setSteering(float steeringAmount){
        amountOfSteering = maxSteeringAngle * steeringAmount;
    }
    void Start()
    {
    }

    void Update(){
        amountOfMotor = maxTorque * Input.GetAxis("Vertical");
        amountOfSteering = maxSteeringAngle * Input.GetAxis("Horizontal");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (AxleInfo axle in axles){
            if (axle.usingSteering){
                axle.leftWheel.steerAngle = amountOfSteering;
                axle.rightWheel.steerAngle = amountOfSteering;
            }
            if (axle.usingMotor){
                axle.leftWheel.motorTorque = amountOfMotor;
                axle.rightWheel.motorTorque = amountOfMotor;
            }
        }
        
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool usingMotor; // is this wheel attached to motor?
    public bool usingSteering; // does this wheel apply steer angle?
}
