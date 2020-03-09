using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Proyecto;
using System;

public class esperandoState : State{

	Agent agente;
	Agent auxiliar;
	List<Transition> transitionsList;
	string name;
	double maxA = 5;
	seekUsingGraphComp sugc;

	public esperandoState(List<Transition> transitions){

		transitionsList = transitions;

	}

	public override void GetAction(){

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