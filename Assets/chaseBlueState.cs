using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Proyecto;

public class ChaseBlueState : State{

	List<Transition> transitionsList;
	Agent objetivo;
	string name;
	Agent agente;
	seekUsingGraphComp sugc;
	Nodo partida;
	Grafo grafoActual = new Grafo();
	double maxA;


	public ChaseBlueState(Agent obj, Agent agent, List<Transition> transitions, double max){

		agente = agent;
		maxA = max;
		transitionsList = transitions;
		objetivo = obj;
		name = "Chase Blue";
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

}
