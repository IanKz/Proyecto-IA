using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Proyecto;

public class ChaseState : State{

	List<Transition> transitionsList;
	Agent objetivo;
	string name;
	Agent agente;
	seekUsingGraphComp sugc;
	Nodo partida;
	Grafo grafoActual = new Grafo();
	double maxA;


	public ChaseState(Agent obj, Agent agent, List<Transition> transitions, double max){

		agente = agent;
		maxA = max;
		transitionsList = transitions;
		objetivo = obj;
		name = "Chase Green";
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