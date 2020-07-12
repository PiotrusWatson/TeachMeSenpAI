using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WatchdogBar : MonoBehaviour
{
    
    public Slider slider;
    public float decayRate; // the rate at which the anger intolerance goes down
    public float increaseRate; // the rate at which the anger intolerance goes up

    // Update is called once per frame
    void Update()
    {
        if (slider.value >= 1)
            exceededWatchdogTolerance();


        /*Have the slider and decrease over time, increase when CTRL is pressed*/
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.Tab))
            slider.value += increaseRate;
        else
            slider.value -= decayRate;
    }


    /*Game over function called when the intolerance is maxed out*/
    private void exceededWatchdogTolerance ()
    {
        
        SceneManager.LoadScene(2);
    }
}
