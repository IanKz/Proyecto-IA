using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dynamicSeek : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double maxAcceleration = 0.1;
	double time;
    Vector3 rotationVector;

    public Vector3 targetPos;

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

    public void getSteering(){

        agent.steering.linear = target.transform.position - agent.transform.position;

        agent.steering.linear.Normalize();

        agent.steering.linear *= (float)maxAcceleration; 

        agent.transform.rotation = agent.newOrientation(agent.transform.rotation, agent.steering.linear);

    }
    
}
