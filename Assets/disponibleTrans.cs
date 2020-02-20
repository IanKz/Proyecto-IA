using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disponibleTrans : Transition
{

	Agent negro;
	Agent azul;
	Agent agente;
	string targetState;

	public disponibleTrans(Agent ag, Agent a, Agent n, string tS){

		azul = a;
		negro = n;
		agente = ag;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if(!azul.cargado && !negro.cargado && !agente.cargado){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}