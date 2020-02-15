using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Align : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double maxAngularAcceleration = 100;
	public double maxRotation = 180;
	public double targetRadius = 0.001;
	public double slowRadius = 0.001;
	public double timeToTarget = 0.1;
    alignComp align;

    void Start(){

        align = new alignComp(agent, target, maxAngularAcceleration, maxRotation, targetRadius, slowRadius, timeToTarget);

    }

    // Update is called once per frame
    void Update()
    {

        align.doYourThing();
        
    }
    
}
