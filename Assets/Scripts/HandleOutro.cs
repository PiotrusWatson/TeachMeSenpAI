using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleOutro : MonoBehaviour
{

    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        if (ProfitScore.win) {
            win.active = true;
        } else {
            lose.active = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
