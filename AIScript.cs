using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    NavMeshAgent myAgent;
    public Transform [] waypoints;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PickWayPoint();
    }
    private void Update()
    {
        if(myAgent.remainingDistance < .25f)
        {
            PickWayPoint();
        }
    }
    void PickWayPoint()
    {
        int randomWPNumber;
        randomWPNumber = Random.Range(0, waypoints.Length);

        myAgent.SetDestination(waypoints[randomWPNumber].position);
    }

}
