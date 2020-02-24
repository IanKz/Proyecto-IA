using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enMetaTrans : Transition
{

	Agent yo;
	Agent otro1;
	Agent otro2;
	string targetState;

	public override string GetName(){
	
		return "enMeta";
	
	}

	public enMetaTrans(Agent agent, Agent a, Agent b, string tS){

		yo = agent;
		otro1 = b;
		otro2 = a;
		targetState = tS;

	}

	public override bool IsTriggered(){

		if(yo.GetEnMeta() || otro1.GetEnMeta() || otro2.GetEnMeta()){

			return true;

		}

		return false;

	}

	public override string GetTargetState(){

		return targetState;

	}

}