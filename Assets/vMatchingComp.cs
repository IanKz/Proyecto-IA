using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vMatchingComp{

	Agent agent;
	Agent target;
	double timeToTarget;
	Vector3 lastTargetPosition;
	Vector3 lastAgentPosition;
	double time;
	double maxAcceleration;
	Vector3 linear;
	Vector3 difTarget;
	Vector3 difAgent;

	public vMatchingComp(Agent agente, Agent objetivo, double timeToT, double maxA){

		agent = agente;
		target = objetivo;
		timeToTarget = timeToT;
		lastAgentPosition = agente.transform.position;
   		lastTargetPosition = objetivo.transform.position;
   		time = Time.deltaTime;
   		maxAcceleration = maxA;

	}

	public void doYourThing(){

    	difTarget = target.transform.position - lastTargetPosition;
    	difAgent = agent.transform.position - lastAgentPosition;
    	linear = new Vector3((float)(difTarget[0]/time), (float)(difTarget[1]/time), (float)(difTarget[2]/time)) - 
    				new Vector3((float)(difAgent[0]/time), (float)(difAgent[1]/time), (float)(difAgent[2]/time));
    	linear = new Vector3((float)(linear[0]/timeToTarget), (float)(linear[1]/timeToTarget), (float)(linear[2]/timeToTarget));

    	if (linear.magnitude > maxAcceleration){

    		linear.Normalize();
    		linear = new Vector3((float)(linear[0]*maxAcceleration), (float)(linear[1]*maxAcceleration), (float)(linear[2]*maxAcceleration));

    	}

    	agent.transform.position += new Vector3((float)time*linear[0], (float)time*linear[1], (float)time*linear[2]);

    	lastAgentPosition = agent.transform.position;
    	lastTargetPosition = target.transform.position;

	}

}