using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrive : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double radius = 0.1;
	public Vector3 direction;
	public double timeToTarget = 0.01;
	double maxSpeed = 0.5;
	Vector3 rotationVector;


    // Update is called once per frame
    void Update()
    {

    	direction = target.transform.position - agent.transform.position;

        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, direction);

    	if ((Math.Abs(direction.x) + Math.Abs(direction.y) + Math.Abs(direction.z)) < radius){

    		return;

    	}

    	direction.x = direction.x/(float)timeToTarget;
    	direction.y = direction.y/(float)timeToTarget;
    	direction.z = direction.z/(float)timeToTarget;

    	if (direction.magnitude > maxSpeed){

    		direction.Normalize();
    		for (int i = 0; i < 3; i++){

    			direction[i] = direction[i]*(float)maxSpeed;

    		}

    	}

    	agent.transform.position += new Vector3((float)0.1*direction[0], (float)0.1*direction[1], (float)0.1*direction[2]);

        
    }

}
