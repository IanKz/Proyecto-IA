using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleAvoidance : dynamicSeek
{

	public float avoidDistance;
	public float lookahead;
	Vector3 ray;
	public List<GameObject> obstacles;
    dSeekComp dsc;

    // Start is called before the first frame update
    void Start()
    {

        dsc = new dSeekComp(agent, target, maxAcceleration, targetPos);

    }

    // Update is called once per frame
    void Update()
    {

    	Collision collision;

    	ray = agent.velocity;
    	ray.Normalize();
    	ray *= lookahead;

    	collision = this.getCollisions(agent.transform.position, ray);

    	if (collision.normal == Vector3.zero){

    		return;

    	}

    	targetPos = -(collision.position + collision.normal*avoidDistance);

    	if(!agent.col){

    		dsc.doYourThing();

    	}
    	else{

    		agent.steering.linear = targetPos - agent.transform.position;

    		agent.steering.linear.Normalize();

        	agent.steering.linear *= (float)maxAcceleration;


            agent.velocity += agent.steering.linear * Time.deltaTime;

            agent.rotation += agent.steering.angular * Time.deltaTime;
            agent.transform.position += agent.velocity * Time.deltaTime;
            agent.transform.rotation = Quaternion.Euler(0,0,agent.transform.rotation.eulerAngles.z + agent.rotation * Time.deltaTime * Mathf.Rad2Deg);
            // Update velocity and rotation

            if (agent.velocity.magnitude >agent.maxSpeed){
                agent.velocity.Normalize();
                agent.velocity *= agent.maxSpeed;

            } 

    	}

    }

    public Collision getCollisions(Vector3 position, Vector3 ray){

    	Collision actualCollision;

    	GameObject candidate;

    	Vector3 normal;

    	Vector3 rayPosition = position + ray; 

    	foreach (GameObject obstacle in obstacles){

    		if (rayPosition.x >= (obstacle.transform.position.x - obstacle.transform.localScale.x/2 - 0.5) &&
    			rayPosition.x <= (obstacle.transform.position.x + obstacle.transform.localScale.x/2 + 0.5) &&
    			rayPosition.y >= (obstacle.transform.position.y - obstacle.transform.localScale.y/2 - 0.5) &&
    			rayPosition.y <= (obstacle.transform.position.y + obstacle.transform.localScale.y/2 + 0.5)){
    			candidate = obstacle;
    			normal = obstacle.transform.position - position;

    			actualCollision = new Collision(rayPosition, normal);

    			agent.col = true;

    			return actualCollision;

    		}

    	}

    	agent.steering.linear = target.transform.position - agent.transform.position;
    	agent.col = false;

    	actualCollision = new Collision(Vector3.zero, Vector3.zero);

    	return actualCollision;

    }
}

public class Collision{

	public Vector3 position;
	public Vector3 normal;

	public Collision(Vector3 pos, Vector3 norm){

		position = pos;
		normal = norm;

	}

}




