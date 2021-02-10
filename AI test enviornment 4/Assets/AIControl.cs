using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	UnityEngine.AI.NavMeshAgent agent;
	Animator anim;
	float speedMult;
	float dtecR = 5;
	float fleeR = 10;

	void ResetAgent()
    {
		speedMult = Random.Range(0.1f, 1.5f);
		agent.speed = 2 * speedMult;
		agent.angularSpeed = 120;
		anim.SetFloat("speedMult", speedMult);
		anim.SetTrigger("isWalking");
		agent.ResetPath();
    }

	public void DetectNewObstacle(Vector3 position)
    {
		if (Vector3.Distance(position, this.transform.position) < dtecR)
        {
			Vector3 fleeDir = (this.transform.position - position).normalized;
			Vector3 newgoal = this.transform.position + fleeDir * fleeR;

			NavMeshPath path = new NavMeshPath();
			agent.CalculatePath(newgoal, path);

			if(path.status != NavMeshPathStatus.PathInvalid)
            {
				agent.SetDestination(path.corners[path.corners.Length - 1]);
				anim.SetTrigger("isRunning");
				agent.speed = 10;
				agent.angularSpeed = 500;
            }
        }
    }

	// Use this for initialization
	void Start () {
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
		anim = this.GetComponent<Animator>();
		anim.SetFloat("wOffset", Random.Range(0, 1));
		ResetAgent();
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.remainingDistance < 1)
        {
			ResetAgent();
			agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
	}
}
