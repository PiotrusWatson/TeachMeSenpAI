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

    
    Dictionary<Command, float> commandToMaxTime; 

    void remakeDictSmiley(){
        
    }
    
    

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
    }

    // Update is called once per frame
    void Update()
    {
        if (commandTimer < maxCommandTimer){
            commandTimer += Time.unscaledDeltaTime;
        }
        else{
            motor.setMotor(1.0f);
            motor.setSteering(Random.Range(-1.0f, 1.0f));
        }

    }

    public void GiveCommand(Command command){
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
                motor.setMotor(0.3f);
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
