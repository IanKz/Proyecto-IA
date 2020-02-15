using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{

	public double maxPrediction;
	public Agent agent;
	public Agent target;
    pursueComp pComp;

    // Start is called before the first frame update
    void Start()
    {

   		pComp = new pursueComp(agent, target, maxPrediction);

    }

    // Update is called once per frame
    void Update()
    {

        pComp.doYourThing();

    }

}
