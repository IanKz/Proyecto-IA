using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disponibleTrans : Transition
{

	Agent otro1;
	Agent otro2;
	Agent yo;
	string targetState;
	public override string GetName(){
	
		return "disponible";
	
	}

	public disponibleTrans(Agent ag, Agent a, Agent n, string tS){

		otro1 = a;
		otro2 = n;
		yo = ag;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if(!otro1.cargado && !otro2.cargado && !yo.cargado){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}