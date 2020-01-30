using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jumpingPoint : MonoBehaviour
{

	public Agent agent;
	public Agent jumpPad;
	JumpPoint jp = new JumpPoint();
	float maxSpeed = 10;
	Agent target = null;
	float gravity = (float)-9.8;
	float maxZVelocity = 5;
    public bool canAchieve = false;
    Vector3 direction;
    float distance;
    float maxAcceleration = 10;
    public Vector3 velocityNeeded;
    public bool guard;
    double time;

    // Update is called once per frame
    void Update()
    {

    	time = Time.deltaTime;

    	if (target == null){

    		this.calculateTarget();

    	}

    	if (!canAchieve){

    		agent.jump = false;
    		agent.steering.linear = Vector3.zero;
    		return;

    	}

    	direction = agent.transform.position - jumpPad.transform.position;
    	distance = direction.magnitude;

    	guard = distance <= 1 && (velocityNeeded.magnitude < agent.velocity.magnitude);

    	if (guard){

    		agent.jump = true;
    		agent.steering.linear = new Vector3(0f,0f,maxAcceleration);
    		agent.transform.position += new Vector3(0, 0, (float)(agent.steering.linear.z*time));
    		return;

    	}

    	agent.steering.linear = Vector3.zero;

    	return;
        
    }

    private void calculateTarget(){

    	float time;
    	float sqrtTerm;

    	sqrtTerm = (float)Math.Sqrt(2*gravity*agent.jp.deltaPos.z +
    							maxZVelocity*maxZVelocity);

    	time = (maxZVelocity - sqrtTerm)/gravity;

    	if (!(this.checkJumpTime(time))){

    		time = (maxZVelocity + sqrtTerm)/gravity;
    		this.checkJumpTime(time);

    	}

    }

    private bool checkJumpTime(float time){

    	float speedSq;
    	float vx;
    	float vy;

    	vx = (agent.jp.deltaPos.x/3)*time;
    	vy = (agent.jp.deltaPos.y/3)*time;
    	speedSq = vx*vx + vy*vy;

    	if (speedSq < maxSpeed*maxSpeed){
    		velocityNeeded = new Vector3(vx, vy, 0);
    		canAchieve = true;

    	}
    	else{

    		canAchieve = false;

    	}
    	return false;

    }
}

public class JumpPoint{

	public Vector3 pointPos;

	public Vector3 landingPos;

	public Vector3 deltaPos; 

	public JumpPoint(){

		pointPos = new Vector3((float)2, (float)2, 0);
		landingPos = Vector3.zero;
		deltaPos = landingPos - pointPos;

	}

}