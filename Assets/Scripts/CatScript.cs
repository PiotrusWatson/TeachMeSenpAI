using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatScript : MonoBehaviour
{

    public Transform start;
    public Transform end;
    public float sensitivity;

    NavMeshAgent agent;
    Vector3 startGoal;
    Vector3 endGoal;
    Vector3 currentGoal;

    // Start is called before the first frame update
    void Start()
    {

        startGoal = new Vector3(start.position.x, 0, start.position.z);
        endGoal = new Vector3(end.position.x, 0, end.position.z);

        transform.position = startGoal;

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(endGoal);
        currentGoal = endGoal;

        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.remainingDistance);
         if (!agent.pathPending && agent.remainingDistance < sensitivity)

            if (currentGoal == endGoal) {
                agent.SetDestination(startGoal);
                currentGoal = startGoal;
            } else if (currentGoal == startGoal) {
                agent.SetDestination(endGoal);
                currentGoal = endGoal;
            }
    }
}
