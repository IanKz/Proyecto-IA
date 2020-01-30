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


    void getNewOrientation(Vector3 direction){

        if (direction.magnitude > 0){

            rotationVector = agent.transform.rotation.eulerAngles;
            rotationVector.z += (float)Math.Sin(-direction[0]*(Math.PI / 180))/(float)Math.Cos(direction[2]*(Math.PI / 180));
            agent.transform.rotation = Quaternion.Euler(rotationVector);

        }

    }

    public void getSteering(){

        agent.steering.linear = target.transform.position - agent.transform.position;

        agent.steering.linear.Normalize();

        agent.steering.linear *= (float)maxAcceleration; 

    }
    
}
