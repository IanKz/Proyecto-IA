using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekUsingGraph : MonoBehaviour
{

    public Agent agent;
    public Agent target;
    public double maxA;
    seekUsingGraphComp sugc;

    // Start is called before the first frame update
    void Start()
    {

        sugc = new seekUsingGraphComp(agent, target.transform.position, maxA);
        
    }

    // Update is called once per frame
    public void Update()
    {

        sugc.DoYourThing();

	}


}
