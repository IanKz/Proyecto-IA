using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentMovement : MonoBehaviour
{

	public Agent agent;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    	agent.steering.linear[1] += (float)0.02;

    }
}
