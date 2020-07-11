using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashboardController : MonoBehaviour
{
    public GameObject buttonDashboardTemplate;
    GameObject buttonDashboard;
    SmoothMouseLook mouseLook;

    AutomaticController autoScript;


    // Start is called before the first frame update
    void Awake()
    {
        autoScript = GetComponent<AutomaticController>();
        buttonDashboard = GameObject.FindGameObjectWithTag("Buttons");
        
        mouseLook = Camera.main.GetComponent<SmoothMouseLook>();
    }

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")){
            buttonDashboard.SetActive(true);
            mouseLook.enabled = false;
        }
        else{
            buttonDashboard.SetActive(false);
            mouseLook.enabled = true;
        }
    }
}
