using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wanderingComp{
	
	Agent target;
	Vector3 rotationVector;

	public wanderingComp(Agent agente){

		target = agente;

	}

	public void doYourThing(){

        rotationVector = target.transform.rotation.eulerAngles;
        rotationVector.Normalize();

        rotationVector.z += UnityEngine.Random.Range(0, 20) - UnityEngine.Random.Range(0, 40);
        target.transform.position += new Vector3((float)-0.01*(float)Math.Sin(rotationVector.z/57), (float)0.01*(float)Math.Cos(rotationVector.z/57), (float)-0.01*(float)rotationVector.z/57);
        target.transform.rotation = Quaternion.Euler(rotationVector);

	}

}