using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{

	public double maxPrediction;
	double prediction;
	GameObject agent;
	GameObject target;
	Vector3 direction;
	double distance;
	Vector3 lastTargetPosition;
	Vector3 lastAgentPosition;
	Vector3 difTarget;
	Vector3 difAgent;
	double speed;
	Vector3 velocity;
	double time;
	Vector3 velocity2;
	Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    	agent = GameObject.Find("agent");
    	target = GameObject.Find("target");
   		time = Time.deltaTime;
   		lastAgentPosition = agent.transform.position;
   		lastTargetPosition = target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    	difTarget = target.transform.position - lastTargetPosition;
    	difAgent = agent.transform.position - lastAgentPosition;

    	direction = target.transform.position - agent.transform.position;
    	distance = direction.magnitude;

    	velocity = new Vector3((float)(difAgent[0]/time), (float)(difAgent[1]/time), (float)(difAgent[2]/time));
    	velocity2 = new Vector3((float)(difTarget[0]/time), (float)(difTarget[1]/time), (float)(difTarget[2]/time));

        speed = velocity.magnitude;

        if (speed <= distance/maxPrediction){

        	prediction = maxPrediction;

        }
        else{

        	prediction = distance/speed;

        }

        position = target.transform.position;
        position = new Vector3((float)(direction[0] + (velocity2[0]*prediction)), (float)(direction[1] + (velocity2[1]*prediction)), (float)(direction[2] + (velocity2[2]*prediction)));
        position.Normalize();
        agent.transform.position += new Vector3((float)(position[0]*time), (float)(position[1]*time), (float)(position[2]*time));

    	lastAgentPosition = agent.transform.position;
    	lastTargetPosition = target.transform.position;

    }

}
