using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashboardController : MonoBehaviour
{
    public GameObject buttonDashboardTemplate;

    public GameObject topDownCamera;
    GameObject mainCamera;
    GameObject buttonDashboard;
    SmoothMouseLook mouseLook;

    AutomaticController autoScript;


    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main.gameObject;
        autoScript = GetComponent<AutomaticController>();
        buttonDashboard = GameObject.FindGameObjectWithTag("Buttons");
        if (topDownCamera == null){
            topDownCamera = GameObject.Find("TopDownCamera");
        }
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

        if (Input.GetButton("Tab")){
            topDownCamera.SetActive(true);
            mainCamera.SetActive(false);
        }
        else{
            topDownCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
    }
}
