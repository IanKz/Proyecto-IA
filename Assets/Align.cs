using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Align : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double maxAngularAcceleration = 100;
	public double maxRotation = 180;
	public double targetRadius = 0.001;
	public double slowRadius = 0.001;
	public double timeToTarget = 0.1;
	double rotation;
	double angular;
	double time;
	double angularAcceleration;
	double rotationSize;
	double targetRotation;
	Vector3 agentRotation;


    void Start(){

        time = Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {

        this.doYourThing();
        
    }

    public void doYourThing(){

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
