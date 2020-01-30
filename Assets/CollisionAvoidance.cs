using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{

	public Agent agent;
	public Agent[] targets;
	public float radius;
	Agent closestTarget;
	Vector3 distVector;
	float shortestTime;
	Agent firstTarget = null;
	float firstMinSeparation;
	float firstDistance;
	Vector3 firstRelativePos;
	Vector3 firstRelativeVel;
	float maxAcceleration = 5;

	Vector3 relativePos;
	Vector3 relativeVel;
	float relativeSpeed;
	float timeToCollision;
	float distance;
	float minSeparation;


	void Start(){

    	shortestTime = float.PositiveInfinity;
    	
    	firstTarget = null;
    	firstMinSeparation = 0;
    	firstDistance = 0;
    	firstRelativeVel = Vector3.zero;
    	firstRelativePos = Vector3.zero;

	}

    // Update is called once per frame
    void Update()
    {

    	foreach (Agent target in targets){

    		relativePos = target.transform.position - agent.transform.position;

    		relativeVel = target.velocity - agent.velocity;
    		relativeSpeed = relativeVel.magnitude;

    		timeToCollision = Vector3.Dot(relativePos,relativeVel)/(relativeSpeed*relativeSpeed);

    		distance = relativePos.magnitude;
    		minSeparation = distance-relativeSpeed*shortestTime;

    		Debug.Log("minSeparation: " + minSeparation + " distance: " + distance + " shortestTime: " + shortestTime +" timeToCollision: " + timeToCollision + "relativePos: " + relativePos);

    		if (minSeparation <= 2*radius){
    			if ((timeToCollision > 0) && timeToCollision < shortestTime){

    				Debug.Log("entra");

    				shortestTime = timeToCollision;
    				firstTarget = target;
    				firstMinSeparation = minSeparation;
    				firstDistance = distance;
    				firstRelativePos = relativePos;
    				firstRelativeVel = relativeVel;

    			}
    		}

    	}

    	if (firstTarget){

    		Vector3 relativePos;

    		if (firstMinSeparation <= 0 || firstDistance < 2*radius){

    			relativePos = firstTarget.transform.position - agent.transform.position;

    		}
    		else{

    			relativePos = firstRelativePos + firstRelativeVel*shortestTime;

    		}

    		relativePos.Normalize();
    		agent.steering.linear = relativePos*maxAcceleration;

    	}

    }
}
