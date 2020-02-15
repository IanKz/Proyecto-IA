using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    
    public Agent agent;
    public Agent target;
    private seekComp sk;

    void Start(){

    	sk = new seekComp(agent, target);

    }

    // Update is called once per frame
    void Update()
    {

    	sk.getSteering();

    }
}
