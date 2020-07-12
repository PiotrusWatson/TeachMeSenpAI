using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* To add a command, add the logic to automatic controller, change the enum (in automatic controller, and add an endpoint here).
this is badly handled i know :(*/

public class CarCommands : MonoBehaviour
{
    AutomaticController commandGiver;
    // Start is called before the first frame update
    void Awake()
    {

        commandGiver = GetComponent<AutomaticController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
