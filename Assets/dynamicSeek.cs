using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dynamicSeek : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double maxAcceleration = 2;
    public Vector3 targetPos;
    dSeekComp dsc;

    // Start is called before the first frame update
    void Start()
    {
        
        dsc = new dSeekComp(agent, target, maxAcceleration, targetPos);

    }

    // Update is called once per frame
    void Update()
    {
        dsc.doYourThing();
    }
    
}
