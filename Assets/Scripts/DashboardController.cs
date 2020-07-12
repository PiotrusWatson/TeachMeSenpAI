using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashboardController : MonoBehaviour
{
    public GameObject canvasTemplate;
    GameObject canvas;
    public GameObject topDownCameraTemplate;

    GameObject topDownCamera;
    GameObject mainCamera;
    GameObject buttonDashboard;

    public GameObject goals;
    
    SmoothMouseLook mouseLook;

    AutomaticController autoScript;


    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main.gameObject;
        autoScript = GetComponent<AutomaticController>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject check = GameObject.FindGameObjectWithTag("Buttons");
        topDownCamera = GameObject.Find("TopDownCamera");
        if (topDownCamera == null){
            topDownCamera = Instantiate(topDownCameraTemplate, topDownCameraTemplate.transform.position, topDownCameraTemplate.transform.rotation);
        }

        if (canvas != null && check == null){
            Destroy(canvas);
            canvas = Instantiate(canvasTemplate);
        }
        
        if (canvas == null) {
            canvas = Instantiate(canvasTemplate);
        }
        
        mouseLook = Camera.main.GetComponent<SmoothMouseLook>();
    }

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)){
            toggleDashboard(true);
            mouseLook.enabled = false;
        }
        else{
            toggleDashboard(false);
            mouseLook.enabled = true;
        }

        if (Input.GetButton("Tab")){
            topDownCamera.SetActive(true);
            mainCamera.SetActive(false);

            // set all goal markers to rendered
            goals.GetComponent<GoalPathScript>().renderGoalMarkers(true);
        }
        else
        {
            topDownCamera.SetActive(false);
            mainCamera.SetActive(true);

            // set all goal markers to unrendered
            goals.GetComponent<GoalPathScript>().renderGoalMarkers(false);
        }
    }

    void toggleDashboard(bool isActive){
         foreach (Transform child in canvas.transform){
                if (child.gameObject.CompareTag("Buttons")){
                    child.gameObject.SetActive(isActive);   
                }
                //else{
                //    child.gameObject.SetActive(!isActive);
                //}
            }
    }
}
