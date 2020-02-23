using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Proyecto;

public class cargadoState : State{

	Agent agente;
	Agent objetivo;
	List<Transition> transitionsList;
	Vector3 meta;
	seekUsingGraphComp sugc;
	string name;

	public cargadoState(Agent ag, Agent obj, List<Transition> transitions, double maxA){

		agente = ag;
		transitionsList = transitions;
		objetivo = obj;
		sugc = new seekUsingGraphComp(agente, objetivo, maxA);

	}

	public override void GetAction(){

		sugc.DoYourThing();

	}

	public override List<Transition> GetTransitions(){

		return transitionsList;

	}

	public override string GetName(){

		return name;

	}

	public void SetName(string nombre){

		name = nombre;

	}

}