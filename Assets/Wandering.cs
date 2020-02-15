using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wandering : MonoBehaviour
{

	public Agent target;
	Vector3 rotationVector;
    wanderingComp wComp;

    void Start(){

        wComp = new wanderingComp(target); 

    }

    // Update is called once per frame
    void Update()
    {

        wComp.doYourThing();

    }
}
