using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCommand : MonoBehaviour
{

    public Command command;
    AutomaticController commandController; 
    // Start is called before the first frame update
    void Start()
    {
        commandController = GameObject.FindGameObjectWithTag("Player").GetComponent<AutomaticController>();
    }

    // Update is called once per frame
    public void GiveCommand(){
        commandController.GiveCommand(command);
    }
}
