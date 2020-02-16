using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dArriveComp
{
	Agent agent;
	Vector3 target;
	double maxSpeed;
	double maxAcceleration;
	double targetRadius;
	double slowRadius;
	double timeToTarget;
	double time;
	Vector3 velocity;

    // Start is called before the first frame update
    public dArriveComp(Agent agente, Vector3 objetivo, double maxS, double maxA, double targetR, double slowR, double timeToT){

    	agent = agente;
    	target = objetivo;
    	maxSpeed = maxS;
    	maxAcceleration = maxA;
    	targetRadius = targetR;
    	slowRadius = slowR;
    	timeToTarget = timeToT;
    	time = Time.deltaTime;
    	velocity = Vector3.zero;

    }

    // Update is called once per frame
	public void doYourThing(){

  		Vector3 direction;
  		double distance;
  		double targetSpeed;
  		Vector3 targetVelocity;
  		Vector3 linear;

    	direction = target - agent.transform.position;

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
        
      agent.transform.rotation = agent.newOrientation(agent.transform.rotation, direction);

    }
}
