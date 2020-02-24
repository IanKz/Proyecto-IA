using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitingForFoodTrans : Transition
{

	Agent otro2;
	Agent otro1;
	string targetState;
	public override string GetName(){
	
		return "waitingForFood";
	
	}

	public waitingForFoodTrans(Agent a, Agent n, string tS){

		otro2 = a;
		otro1 = n;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if(otro1.cargado || otro2.cargado){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}