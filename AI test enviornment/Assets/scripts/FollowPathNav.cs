using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathNav : MonoBehaviour
{
    
    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    public void GoToNE()
    {
        agent.SetDestination(wps[9].transform.position);
        //g.AStar(currentNode, wps[9]);
        //currentWP = 0;
    }

    public void GoToSE()
    {
        agent.SetDestination(wps[2].transform.position);
        //g.AStar(currentNode, wps[2]);
        //currentWP = 0;
    }
    public void GoToC()
    {
        agent.SetDestination(wps[11].transform.position);
        //g.AStar(currentNode, wps[11]);
        //currentWP = 0;
    }
    public void GoToSW()
    {
        agent.SetDestination(wps[5].transform.position);
        //g.AStar(currentNode, wps[5]);
        //currentWP = 0;
    }
    public void GoToNW()
    {
        agent.SetDestination(wps[7].transform.position);
        //g.AStar(currentNode, wps[7]);
        //currentWP = 0;
    }
    // Update is called once per frame
    void LateUpdate()
    {
       
    }
}
