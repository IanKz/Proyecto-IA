using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dSeekComp{

	Agent agent;
	Vector3 target;
	double maxAcceleration;
	Vector3 targetPos;
	double time;

	public dSeekComp(Agent agente, Vector3 posicionObj, double maxA, Vector3 targetP){

		agent = agente;
		target = posicionObj;
		maxAcceleration = maxA;
		targetPos = targetP;
		time = Time.deltaTime;

	}

	public void doYourThing(){

        agent.steering.linear = target - agent.transform.position;

        agent.steering.linear.Normalize();

        agent.steering.linear *= (float)maxAcceleration; 

        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, agent.steering.linear);		

	}

}