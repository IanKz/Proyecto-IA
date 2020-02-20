using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Proyecto;

public class esperandoState : State{

	Agent agente;
	List<Transition> transitionsList;
	string name;

	public esperandoState(Agent ag, List<Transition> transitions){

		agente = ag;
		transitionsList = transitions;

	}

	public override void GetAction(){

		System.Threading.Thread.Sleep(250);

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