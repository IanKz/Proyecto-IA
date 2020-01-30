using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wandering : MonoBehaviour
{

	public Agent target;
	Vector3 rotationVector;


    // Update is called once per frame
    void Update()
    {

        rotationVector = target.transform.rotation.eulerAngles;
        rotationVector.Normalize();

        rotationVector.z += UnityEngine.Random.Range(0, 20) - UnityEngine.Random.Range(0, 40);
        target.transform.position += new Vector3((float)-0.01*(float)Math.Sin(rotationVector.z/57), (float)0.01*(float)Math.Cos(rotationVector.z/57), (float)-0.01*(float)rotationVector.z/57);
        target.transform.rotation = Quaternion.Euler(rotationVector);
    }
}
