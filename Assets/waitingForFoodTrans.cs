using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitingForFoodTrans : Transition
{

	Agent negro;
	Agent azul;
	Agent agente;
	string targetState;

	public waitingForFoodTrans(Agent ag, Agent a, Agent n, string tS){

		azul = a;
		negro = n;
		agente = ag;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if(negro.cargado || azul.cargado){

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}