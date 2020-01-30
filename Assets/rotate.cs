using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{

	GameObject target;
	Vector3 rotationVector;
	double xPosition;

    // Start is called before the first frame update
    void Start()
    {

		target = GameObject.Find("target");
    	rotationVector = target.transform.rotation.eulerAngles;
    	
        
    }

    // Update is called once per frame
    void Update()
    {

   		rotationVector.z += 5;
   		target.transform.rotation = Quaternion.Euler(rotationVector);
  		target.transform.position += new Vector3((float)0.1, 0, 0);

    }
}