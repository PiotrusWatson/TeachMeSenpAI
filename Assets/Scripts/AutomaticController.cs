using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* To add a command, add the logic here, change the enum (in automatic controller) */

public enum Command{SWERVE_LEFT, SWERVE_RIGHT, BRAKE, TURN_LEFT, TURN_RIGHT, SLOW_DOWN}

public class AutomaticController : MonoBehaviour
{

    CarMotor motor;
    public GameObject AINavigatorTemplate;
    public NavMeshAgent AINavigator;

    //dummy value :)
    float maxCommandTimer =999f;
    float commandTimer;
    public float turningMaxTime;
    public float swervingMaxTime;
    public float brakingMaxTime;
    public float slowingMaxTime;
    private Command lastCommand;
    private float lastTimer = 0;
    public float speedUpRate;
    private float motorSpeed;

    
    Dictionary<Command, float> commandToMaxTime; 
    

    // Start is called before the first frame update

    void Awake(){
        //storing the lengths of each command in the dict :)
        commandToMaxTime = new Dictionary<Command, float>()
    {
        {Command.SWERVE_LEFT, swervingMaxTime},
        {Command.SWERVE_RIGHT, swervingMaxTime},
        {Command.TURN_LEFT, turningMaxTime},
        {Command.TURN_RIGHT, turningMaxTime},
        {Command.BRAKE, brakingMaxTime},
        {Command.SLOW_DOWN, slowingMaxTime}

    };

        motor = GetComponent<CarMotor>();

        if (!GameObject.Find(AINavigatorTemplate.name)){
            GameObject AIObject = Instantiate(AINavigatorTemplate);
            AINavigator = AIObject.GetComponent<NavMeshAgent>();
        }
    }
    void Start()
    {
        commandTimer = maxCommandTimer;
        motorSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Clamp z rotation between -30 and 30 degrees
        Vector3 rot = transform.eulerAngles;
        if(rot.z > 30){
            rot -= new Vector3(0,0,1) * Time.deltaTime * 20;
            transform.eulerAngles = rot;
        } else if(rot.z < -30){
            rot += new Vector3(0,0,1) * Time.deltaTime * 20;
            transform.eulerAngles = rot;
        }
        
        if (commandTimer < maxCommandTimer){
            commandTimer += Time.unscaledDeltaTime;

            if(lastTimer <= swervingMaxTime/2 && commandTimer >= swervingMaxTime/2){
                if(lastCommand == Command.SWERVE_LEFT){
                    motor.setSteering(1f);
                } else if (lastCommand == Command.SWERVE_RIGHT){
                    motor.setSteering(-1f);
                }
            }

            lastTimer = commandTimer;
        }
        else{
            if (motorSpeed < 1.0f)
                motorSpeed += speedUpRate;
                motor.setMotor(motorSpeed);
            motor.setSteering(0f);
        }

    }

    public void GiveCommand(Command command){
        lastCommand = command;
        setTimers(command);
        switch(command){
            case Command.SWERVE_LEFT:
                motor.setSteering(-1f);
                break;
            case Command.SWERVE_RIGHT:
                motor.setSteering(1f);
                break;
            case Command.BRAKE:
                motor.setMotor(-1f);
                break;
            case Command.TURN_LEFT:
                motor.setSteering(-1f);
                break;
            case Command.TURN_RIGHT:
                motor.setSteering(1f);
                break;
            case Command.SLOW_DOWN:
                motorSpeed *= -0.1f;
                motor.setMotor(motorSpeed);
                break;

        }
    }

    /* given a command, finds how long it should take, sets it
    also resets the command timer :)*/
    public void setTimers(Command command){
        commandTimer = 0;
        maxCommandTimer = commandToMaxTime[command];

    }

}
