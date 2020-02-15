using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityMatching : MonoBehaviour
{

	public Agent agent;
	public Agent target;
	public double timeToTarget;
    vMatchingComp vMatch;
    public double maxAcceleration = 1;

    // Start is called before the first frame update
    void Start()
    {
       	
        vMatch = new vMatchingComp(agent, target, timeToTarget, maxAcceleration);

    }

    void Update(){

        vMatch.doYourThing();

    }

    // Update is called once per frame}
}
