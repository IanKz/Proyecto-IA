using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSM : MonoBehaviour
{

	public Agent verde;
	public Agent azul;
	public Agent negro;
	public Agent agent;
	public double maxA;
	List<State> estados;
	Transition transicionDisparada;
	State estadoActual;

    // Start is called before the first frame update
    void Start()
    {
        
    	estados = new List<State>();

    	List<Transition> chaseGreenTrans = new List<Transition>(); 
    	chaseGreenTrans.Add(new gotToTrans(verde, agent, "Chase Green"));
    	ChaseState cgs = new ChaseState(verde, agent, chaseGreenTrans, maxA);
    	cgs.SetName("Chase Blue");
    	estados.Add(cgs);

    	List<Transition> chaseBlueTrans = new List<Transition>(); 
    	chaseBlueTrans.Add(new gotToTrans(azul, agent, "Chase Blue"));
    	ChaseState cbs = new ChaseState(azul, agent, chaseBlueTrans, maxA);
    	cgs.SetName("Chase Black");
    	estados.Add(cbs);

    	List<Transition> chaseBlackTrans = new List<Transition>(); 
    	chaseBlackTrans.Add(new gotToTrans(negro, agent, "Chase Black"));
    	ChaseState cbbs = new ChaseState(negro, agent, chaseBlackTrans, maxA);
    	cgs.SetName("Chase Green");
    	estados.Add(cbbs);

    	estadoActual = cgs;

    }

    // Update is called once per frame
    void Update()
    {
        
    	transicionDisparada = null;

    	foreach(Transition transition in estadoActual.GetTransitions()){

    		if (transition.IsTriggered()){

    			transicionDisparada = transition;
    			break;

    		}

    	}

    	if(transicionDisparada != null){

    		string nuevoEstado = transicionDisparada.GetTargetState();

    		foreach(State s in estados){

    			if(s.GetName().Equals(nuevoEstado)){

    				estadoActual = s;

    			}

    		}

    	}

    	estadoActual.GetAction();

    }
}
