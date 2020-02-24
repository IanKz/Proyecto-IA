using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotToTrans : Transition
{

	Agent agent;
	Agent target;
	string targetState;

	public override string GetName(){
	
		return "goTo";
	
	}

	public gotToTrans(Agent obj, Agent ag, string tS){

		target = obj;
		agent = ag;
		targetState = tS;

	}

	public override bool IsTriggered(){

		if((agent.transform.position - target.transform.position).magnitude <= 2){

			return true;

		}

		return false;

	}

	public override string GetTargetState(){

		return targetState;

	}

}
