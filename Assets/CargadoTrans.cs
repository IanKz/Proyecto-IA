using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadoTrans : Transition
{

	Agent otro2;
	Agent otro1;
	Agent otro3;
	string targetState;

	public override string GetName(){
	
		return "Cargado";
	
	}

	public CargadoTrans(Agent a, string tS){

		otro1 = a;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if(otro1.cargado){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}
