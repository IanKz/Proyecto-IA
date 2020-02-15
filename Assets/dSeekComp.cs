using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dSeekComp{

	Agent agent;
	Agent target;
	double maxAcceleration;
	Vector3 targetPos;
	double time;

	public dSeekComp(Agent agente, Agent objetivo, double maxA, Vector3 targetP){

		agent = agente;
		target = objetivo;
		maxAcceleration = maxA;
		targetPos = targetP;
		time = Time.deltaTime;

	}

	public void doYourThing(){

        agent.steering.linear = target.transform.position - agent.transform.position;

        agent.steering.linear.Normalize();

        agent.steering.linear *= (float)maxAcceleration; 

        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, agent.steering.linear);		

	}

}