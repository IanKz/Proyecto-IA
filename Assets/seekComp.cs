using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class seekComp
{
	
	Agent agent;
	Agent target;
	double time;

	public seekComp(Agent agente, Agent objetivo){

		agent = agente;
		target = objetivo;
     	time = Time.deltaTime;

	}

	public void getSteering(){

        agent.velocity = target.transform.position - agent.transform.position;
        agent.velocity.Normalize();
        agent.velocity += new Vector3((float)agent.maxSpeed*agent.velocity[0], (float)agent.maxSpeed*agent.velocity[1], (float)agent.maxSpeed*agent.velocity[2]);

        agent.transform.position += new Vector3((float)time*agent.velocity[0], (float)time*agent.velocity[1], 0);

        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, agent.velocity);

    }

}