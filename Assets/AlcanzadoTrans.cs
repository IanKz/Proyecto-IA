using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcanzadoTrans : Transition
{

	Agent otro1;
	string targetState;
	Agent agente;
	Agent recurso;
	Vector3 pos;

	public override string GetName(){
	
		return "Alcanzado";
	
	}

	public AlcanzadoTrans(Agent yo, Agent a, Agent goal, Vector3 inicio, string tS){

		recurso = goal;
		pos = inicio;
		agente = yo;
		otro1 = a;
		targetState = tS; 

	}

	public override bool IsTriggered(){

		if((agente.transform.position.x - 0.2 <= otro1.transform.position.x && otro1.transform.position.x <= agente.transform.position.x + 0.2) && 
            (agente.transform.position.y - 0.2 <= otro1.transform.position.y && otro1.transform.position.y <= agente.transform.position.y + 0.2)){

			recurso.transform.position = pos;
			otro1.cargado = false;

			return true;

		}

		return false;

	}


	public override string GetTargetState(){

		return targetState;

	}

}
