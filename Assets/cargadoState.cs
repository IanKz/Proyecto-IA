using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Proyecto;

public class cargadoState : State{

	Agent agente;
	List<Transition> transitionsList;
	Vector3 meta;
	seekUsingGraphComp sugc;
	string name;

	public cargadoState(Agent ag, Vector3 pos, List<Transition> transitions, double maxA){

		agente = ag;
		transitionsList = transitions;
		meta = pos;
		sugc = new seekUsingGraphComp(agente, meta, maxA);

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