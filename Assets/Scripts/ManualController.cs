using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    CarMotor motor; 
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Awake()
    {
        motor = GetComponent<CarMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }
}
