using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    float Timer = 0f;
    int VisitedObjects = 0;
    int ObjectsToVisit = 0;
    float DistanceToObject = 0f;
    public float WaitTime = 2f;

    List<Transform> Waypoints = new List<Transform>();
    public Transform Exit;
    public GameManager gameManager;
    public bool ReachedExit = false;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        if (Exit == null)
        {
            Exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
        }

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("DisplayItem"))
        {
            Waypoints.Add(g.transform);
            ObjectsToVisit++;
        }

        Utilitys.ShuffleArray<Transform>(Waypoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (VisitedObjects < ObjectsToVisit)
        {
            DistanceToObject = Vector3.Distance(Waypoints[VisitedObjects].position, transform.position);
            WaitTime = Waypoints[VisitedObjects].gameObject.GetComponent<DisplayItem>().ReturnWaitingAmount();
        }

        if (ObjectsToVisit > VisitedObjects && DistanceToObject > 2f)
        {            
            MoveToWaypoint(Waypoints[VisitedObjects]);
        }

        if (DistanceToObject < 2f && Timer <= WaitTime)
        {
            //navMeshAgent.enabled = false;
            Timer += Time.deltaTime;
        }

        if (Timer >= WaitTime && ObjectsToVisit > VisitedObjects)
        {
            //navMeshAgent.enabled = true;
            VisitedObjects++;
            Timer = 0;
        }

        if (VisitedObjects == ObjectsToVisit)
        {
            //navMeshAgent.enabled = true;
            MoveToWaypoint(Exit);
        }

        if (Vector3.Distance(Exit.position, transform.position) <= 2f && VisitedObjects == ObjectsToVisit)
        {
            ReachedExit = true;
            gameManager.RemoveVisitor(this.gameObject);
        }
    }
    
    void MoveToWaypoint(Transform way)
    {
        navMeshAgent.destination = way.position;
    }

}
