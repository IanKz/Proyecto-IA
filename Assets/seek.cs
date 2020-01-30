using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class seek : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	Vector3 rotationVector;
	double time;

    // Start is called before the first frame update
    void Start()
    {
     
     	time = Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        
        this.getSteering();

    }

    protected void getSteering(){

        agent.velocity = target.transform.position - agent.transform.position;
        agent.velocity.Normalize();
        agent.velocity += new Vector3((float)agent.maxSpeed*agent.velocity[0], (float)agent.maxSpeed*agent.velocity[1], (float)agent.maxSpeed*agent.velocity[2]);

        agent.transform.position += new Vector3((float)time*agent.velocity[0], (float)time*agent.velocity[1], 0);

        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, agent.velocity);

    }

}
