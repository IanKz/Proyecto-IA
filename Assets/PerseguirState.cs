using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto;

public class PerseguirState : State
{

	List<Transition> transitionsList;
	string name;
	Agent agente;
	seekUsingGraphComp sugc;
	Nodo partida;
	Grafo grafoActual = new Grafo();
	double maxA = 5;
	List<Agent> agentes;


	public PerseguirState(Agent agent, Agent verde, Agent azul, Agent negro, List<Transition> transitions, double max){

		agentes = new List<Agent>();
		agentes.Add(verde);
		agentes.Add(azul);
		agentes.Add(negro);
		agente = agent;
		maxA = max;
		transitionsList = transitions;

	}

	public override void GetAction(){

		Agent aux = new Agent();

		foreach (Agent a in agentes){

			if (a.cargado){

				aux = a;
				break;

			}

		}

		sugc = new seekUsingGraphComp(agente, aux, maxA);
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
