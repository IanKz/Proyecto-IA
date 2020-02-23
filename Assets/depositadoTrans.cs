using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depositadoTrans : Transition
{

	Vector3 pos;
	Agent agente;
	string targetState;

	public depositadoTrans(Agent ag, Agent obj, string tS){

		agente = ag;
		pos = obj.transform.position;
		targetState = tS;

	}

	public override bool IsTriggered(){

		if((agente.transform.position.x - 0.1 <= pos[0] && pos[0] <= agente.transform.position.x + 0.1) && 
            (agente.transform.position.y - 0.1 <= pos[1] && pos[1] <= agente.transform.position.y + 0.1)){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}