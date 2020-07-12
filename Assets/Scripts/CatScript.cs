using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatScript : MonoBehaviour
{

    public int fine;
    public Transform start;
    public Transform end;
    public float sensitivity;

    NavMeshAgent agent;
    Vector3 startGoal;
    Vector3 endGoal;
    Vector3 currentGoal;
    ProfitScore scoreScript;

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

        foreach (Transform child in GameObject.FindGameObjectWithTag("Canvas").transform) {
            if (child.name == "ProfitScore")
                scoreScript = child.GetComponent<ProfitScore>();
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (!agent.pathPending && agent.remainingDistance < sensitivity)

            if (currentGoal == endGoal) {
                agent.SetDestination(startGoal);
                currentGoal = startGoal;
            } else if (currentGoal == startGoal) {
                agent.SetDestination(endGoal);
                currentGoal = endGoal;
            }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            scoreScript.applyFine(fine);
        }
    }
}
