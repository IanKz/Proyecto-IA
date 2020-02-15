using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class seek : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	Vector3 rotationVector;
	seekComp sk;

    // Start is called before the first frame update
    public void Start()
    {

    	sk = new seekComp(agent, target);

    }

    // Update is called once per frame
    void Update()
    {
        
        sk.getSteering();

    }


}
