using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class alignComp{

	private Agent agent;
	private Agent target;
	public double maxAngularAcceleration = 100;
	public double maxRotation = 180;
	public double targetRadius = 0.001;
	public double slowRadius = 0.001;
	public double timeToTarget = 0.1;
	private Vector3 agentRotation = Vector3.zero;
	double time;

	public alignComp(Agent agente, Agent objetivo, double maxAng, double maxR, double targetR, double slowR, double timeToT){

		agent = agente;
		target = objetivo;
		time = Time.deltaTime;
		maxAngularAcceleration = maxAng;
		maxRotation = maxR;
		targetRadius = targetR;
		slowRadius = slowR;
		timeToTarget = timeToT;


	}

    public void doYourThing(){

    	Debug.Log("Hola");

    	double rotation;
		double angular;
		double angularAcceleration;
		double rotationSize;
		double targetRotation;

        rotation = target.transform.rotation.eulerAngles.z - agent.transform.rotation.eulerAngles.z;
        rotation = rotation/57;

        rotationSize = Math.Abs(rotation);

        if (rotationSize < targetRadius){

            return;

        }

        if (rotationSize > slowRadius){

            targetRotation = maxRotation;

        }
        else{

            targetRotation = maxRotation*rotationSize/slowRadius;

        }

        targetRotation = rotation*targetRotation/rotationSize;

        angular = targetRotation - agent.transform.rotation.eulerAngles.z/57;
        angular = angular/timeToTarget;

        angularAcceleration = Math.Abs(angular);

        if (angularAcceleration > maxAngularAcceleration){

            angular = angular/angularAcceleration;
            angular = angular*maxAngularAcceleration;

        }

        agentRotation.z += (float)time*(float)angular;
        agent.transform.rotation = Quaternion.Euler(agentRotation);

    }

}