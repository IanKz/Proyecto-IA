using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yaNoEnMetaTrans : Transition
{

	Agent yo;
	Agent otro1;
	Agent otro2;
	string targetState;
	GameObject objetivo;
	Vector3 inicio;

	public override string GetName(){
	
		return "yaNoEnMeta";
	
	}

	public yaNoEnMetaTrans(Agent agent, Agent a, Agent b, GameObject goal, Vector3 start, string tS){

		inicio = start;
		objetivo = goal;
		yo = agent;
		otro1 = b;
		otro2 = a;
		targetState = tS;

	}

	public override bool IsTriggered(){

		if((yo.GetTiempoPuesto() == 20) || (otro1.GetTiempoPuesto() == 20) || (otro2.GetTiempoPuesto() == 20)){

			objetivo.transform.position = inicio;
			objetivo.SetActive(true);

			return true;

		}

		return false;

	}

	public override string GetTargetState(){

		return targetState;

	}

}