using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depositadoTrans : Transition
{

	Vector3 pos;
	Agent agente;
	string targetState;
	public override string GetName(){
	
		return "depositado";
	
	}

	public depositadoTrans(Agent ag, Agent obj, string tS){

		agente = ag;
		pos = obj.transform.position;
		targetState = tS;

	}

	public override bool IsTriggered(){

		if((agente.transform.position.x - 0.5 <= pos[0] && pos[0] <= agente.transform.position.x + 0.5) && 
            (agente.transform.position.y - 0.5 <= pos[1] && pos[1] <= agente.transform.position.y + 0.5)){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}