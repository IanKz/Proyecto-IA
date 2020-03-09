using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intersectadoTrans : Transition
{

	Agent agente;
	string targetState;
	public override string GetName(){
	
		return "depositado";
	
	}

	public intersectadoTrans(Agent ag, string tS){

		agente = ag;
		targetState = tS;

	}

	public override bool IsTriggered(){

		if(!agente.cargado){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}
