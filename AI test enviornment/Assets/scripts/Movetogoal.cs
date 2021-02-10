using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetogoal : MonoBehaviour
{

    bool ai = false;
    public float speed = 2.0f;
    public float accuracy = 0.01f;
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float calculateDistance()
    {
        Vector3 cubePosition = this.transform.position;
        Vector3 goalPosition = goal.transform.position;

        float distance = Vector3.Distance(cubePosition, goalPosition);

        Debug.Log("Distance: " + distance);
        return distance;
    }
    void calculateAngle()
    {
        Vector3 cubeForward = this.transform.up;
        Vector3 goalDistance = goal.transform.position - this.transform.position;

        float angleToGoal = Vector3.Angle(cubeForward, goalDistance);

        Debug.Log("Angle: " + angleToGoal);

        float angle = Vector3.SignedAngle(cubeForward, goalDistance, this.transform.forward);
        this.transform.Rotate(0, 0, angle);
    }
   
    void Update()
    {

        if ((calculateDistance() > 2) && (calculateDistance() < 30))
        {
            this.transform.LookAt(goal.position);
            Vector3 direction = goal.position - this.transform.position;
            Debug.DrawRay(this.transform.position, direction, Color.red);
            if (direction.magnitude > accuracy)
            {
                this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
        }
       
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            calculateDistance();
            calculateAngle();
        }
    }
}
