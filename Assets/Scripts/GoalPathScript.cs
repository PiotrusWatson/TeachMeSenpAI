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
            Debug.Log("Complete");
            GameObject.Find("LevelCompleteText").GetComponent<Text>().enabled = true;
        }
        List<GameObject> markersToRemove = new List<GameObject>();
        foreach (GameObject marker in markers)
        {
            if (Vector3.Distance(playerCar.transform.position, marker.transform.position) < markDistance)
            {
                marker.GetComponent<MeshRenderer>().enabled = false;
                markersToRemove.Add(marker);
                Debug.Log("Bam");
            }
        }

        foreach (GameObject marker in markersToRemove)
            markers.Remove(marker);
        
    }


    public void renderGoalMarkers (bool render)
    {
        foreach (GameObject marker in markers)
            marker.GetComponent<MeshRenderer>().enabled = render;
    }
}
