using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Treats all of its children as markers
// Once all of the markers were completed enables UI text
public class GoalPathScript : MonoBehaviour
{

    public Transform playerCar;
    public float markDistance;

    List<GameObject> markers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform markerChild in transform) {
            markers.Add(markerChild.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (markers.Count == 0) {
            // Debug.Log("Complete");
            GameObject.Find("LevelCompleteText").GetComponent<Text>().enabled = true;
        } 

        foreach (GameObject marker in markers)
        {
            if (Vector3.Distance(playerCar.transform.position, marker.transform.position) < markDistance)
            {
                markers.Remove(marker);
                // Debug.Log("Bam");
            }
        }
        
    }
}
