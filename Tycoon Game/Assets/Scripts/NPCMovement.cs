using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour {

    NavMeshAgent navMeshAgent;

    public List<Transform> Waypoints = new List<Transform>();

	// Use this for initialization
	void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Waypoints.Count > 0)
        {
            navMeshAgent.destination = Waypoints[0].position;
        }

        if (Vector3.Distance(transform.position, Waypoints[0].position) < 1.5f && Waypoints.Count >= 0)
        {
            Waypoints.Remove(Waypoints[0]);
        }
	}
}
