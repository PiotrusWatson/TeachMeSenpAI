using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Class for controlling the AI (can be applied to both Cars and People)
// It has fairly rudimentary movement that is likely to look like carnage
public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Vector3 destination;
    public float maxDestinationDistance;

    // Start is called before the first frame update
    void Start()
    {
        getRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0f)
            getRandomDestination();
        

    }


    private void getRandomDestination ()
    {
        // get random position
        Vector3 randPos = Random.insideUnitSphere * maxDestinationDistance;
        randPos += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randPos, out hit, maxDestinationDistance, NavMesh.AllAreas);
        destination = hit.position;
        agent.SetDestination(destination);
    }
}
