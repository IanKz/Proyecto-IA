using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursueComp{

    Agent agent;
    Agent target;
    double maxPrediction;
    double time;
    Vector3 lastTargetPosition;
    Vector3 lastAgentPosition;
    double prediction;
    Vector3 direction;
    double distance;
    Vector3 difTarget;
    Vector3 difAgent;
    double speed;
    Vector3 velocity;
    Vector3 velocity2;
    Vector3 position;

    public pursueComp(Agent agente, Agent objetivo, double maxP){

        agent = agente;
        target = objetivo;
        maxPrediction = maxP;
        lastAgentPosition = agent.transform.position;
        lastTargetPosition = target.transform.position;
        time = Time.deltaTime;

    }

    public void doYourThing(){

        difTarget = target.transform.position - lastTargetPosition;
        difAgent = agent.transform.position - lastAgentPosition;

        direction = target.transform.position - agent.transform.position;
        distance = direction.magnitude;
        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, direction);

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