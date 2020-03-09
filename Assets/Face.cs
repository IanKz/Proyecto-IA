using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Face : Align
{
   
   	Vector3 direction;
   	Vector3 rotationVector;
   	Agent newTarget;
    alignComp align;

    void Start(){

        align = new alignComp(agent, target, maxAngularAcceleration, maxRotation, targetRadius, slowRadius, timeToTarget);

    }

    // Update is called once per frame
    void Update()
    {

    	direction = target.transform.position - agent.transform.position;

    	if (direction.magnitude == 0){

    		return;

    	}

    	GameObject go = new GameObject();
    	Agent newTarget = go.AddComponent<Agent>() as Agent;

    	newTarget.transform.position = target.transform.position;
    	rotationVector = new Vector3(0, 0, (float)Math.Atan2(-direction.x, direction.y));
    	target.transform.rotation = Quaternion.Euler(rotationVector);

    	target = newTarget;

    	align.doYourThing();
        
    }
}
