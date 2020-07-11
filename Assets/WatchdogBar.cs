using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchdogBar : MonoBehaviour
{
    
    public Slider slider;
    public float decayRate; // the rate at which the anger intolerance goes down
    public float increaseRate; // the rate at which the anger intolerance goes up

    // Update is called once per frame
    void Update()
    {
        /*Have the slider and decrease over time, increase when CTRL is pressed*/
        if (Input.GetKey(KeyCode.LeftControl))
            slider.value += increaseRate;
        else
            slider.value -= decayRate;
    }
}
