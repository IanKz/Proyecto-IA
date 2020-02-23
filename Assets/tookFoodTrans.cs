using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tookFoodTrans : Transition
{

	Agent agente;
	string targetState;
	Vector3 pos;

	public tookFoodTrans(Agent ag, Agent obj, string tS){

		pos = obj.transform.position;
		agente = ag;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if((agente.transform.position.x - 0.1 <= pos[0] && pos[0] <= agente.transform.position.x + 0.1) && 
            (agente.transform.position.y - 0.1 <= pos[1] && pos[1] <= agente.transform.position.y + 0.1)){
			agente.cargado = true;
			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}