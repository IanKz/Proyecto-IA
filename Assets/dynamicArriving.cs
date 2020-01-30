using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dynamicArriving : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double maxSpeed = 0.5;
	public double maxAcceleration = 0.1;
	public double targetRadius = 0.1;
	public double slowRadius = 15;
	public double timeToTarget = 1;
	Vector3 direction;
	double distance;
	double targetSpeed;
	Vector3 targetVelocity;
	Vector3 linear;
	Vector3 velocity;
	double time;
  Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {

     	time = Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {

    	direction = target.transform.position - agent.transform.position;
      getNewOrientation(direction);
    	distance = direction.magnitude;

    	if (distance < targetRadius){

    		return;

    	}

    	if (distance > slowRadius){

    		targetSpeed = maxSpeed;

    	}
    	else{

    		targetSpeed = maxSpeed*distance/slowRadius;

    	}
    	targetVelocity = direction;
    	targetVelocity.Normalize();
   		targetVelocity = new Vector3((float)targetSpeed*targetVelocity[0], (float)targetSpeed*targetVelocity[1], (float)targetSpeed*targetVelocity[2]);
   		linear = targetVelocity + direction;
   		linear = new Vector3(linear[0]/(float)timeToTarget, linear[1]/(float)timeToTarget, linear[2]/(float)timeToTarget);

   		if (linear.magnitude > maxAcceleration){

   			linear.Normalize();
   			linear = new Vector3((float)maxAcceleration*linear[0], (float)maxAcceleration*linear[1], (float)maxAcceleration*linear[2]);

   		}

   		velocity += new Vector3((float)time*linear[0], (float)time*linear[1], (float)time*linear[2]);
   		agent.transform.position += new Vector3((float)time*velocity[0], (float)time*velocity[1], (float)time*velocity[2]);
        
    }

    void getNewOrientation(Vector3 direction){

      if (direction.magnitude > 0){

        rotationVector = agent.transform.rotation.eulerAngles;
        rotationVector.z += (float)Math.Sin(-direction[0]*(Math.PI / 180))/(float)Math.Cos(direction[2]*(Math.PI / 180));
        agent.transform.rotation = Quaternion.Euler(rotationVector);

      }

    }

}
