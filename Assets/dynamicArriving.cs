using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dynamicArriving : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double maxSpeed = 0.5;
	public double maxAcceleration = 0.1;
	public double targetRadius = 0.1;
	public double slowRadius = 15;
	public double timeToTarget = 1;
  dArriveComp dArrive;

    // Start is called before the first frame update
    void Start()
    {

     	dArrive = new dArriveComp(agent, target.transform.position, maxSpeed, maxAcceleration, targetRadius, slowRadius, timeToTarget);
        
    }

    void Update(){

      dArrive.doYourThing();

    }

}
