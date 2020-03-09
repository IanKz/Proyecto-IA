using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguidorSM : MonoBehaviour
{

	public Agent verde;
	public Agent azul;
	public Agent negro;
	public Agent yo;
	public string elEstado;
	public double maxA;
	public Agent goal;
	Vector3 inicio;
	List<State> estados;
	Transition transicionDisparada;
	State estadoActual;

    // Start is called before the first frame update
    void Start()
    {

    	inicio = goal.transform.position;
        
    	estados = new List<State>();

    	List<Transition> chaseTrans = new List<Transition>();
    	chaseTrans.Add(new AlcanzadoTrans(yo, negro, goal, inicio, "Esperando"));
    	chaseTrans.Add(new disponibleTrans(verde, azul, negro, "Esperando"));
    	ChaseState fs = new ChaseState(yo, negro, chaseTrans, maxA);
    	fs.SetName("Persiguiendo Negro");
    	estados.Add(fs);

    	List<Transition> esperandoTrans = new List<Transition>();
    	esperandoTrans.Add(new CargadoTrans(negro, "Persiguiendo Negro"));
    	esperandoTrans.Add(new CargadoTrans(azul, "Persiguiendo Azul"));
    	esperandoTrans.Add(new CargadoTrans(verde, "Persiguiendo Verde"));
    	esperandoState ss = new esperandoState(esperandoTrans);
    	ss.SetName("Esperando");
    	estados.Add(ss);

    	List<Transition> chaseTrans1 = new List<Transition>();
    	chaseTrans1.Add(new AlcanzadoTrans(yo, azul, goal, inicio, "Esperando"));
    	chaseTrans1.Add(new disponibleTrans(verde, azul, negro, "Esperando"));
    	ChaseState ts = new ChaseState(yo, azul, chaseTrans1, maxA);
    	ts.SetName("Persiguiendo Azul");
    	estados.Add(ts);

    	List<Transition> chaseTrans2 = new List<Transition>();
    	chaseTrans2.Add(new AlcanzadoTrans(yo, verde, goal, inicio, "Esperando"));
    	chaseTrans2.Add(new disponibleTrans(verde, azul, negro, "Esperando"));
    	ChaseState fos = new ChaseState(yo, verde, chaseTrans2, maxA);
    	fos.SetName("Persiguiendo Verde");
    	estados.Add(fos);

    	estadoActual = ss;

    }

    // Update is called once per frame
    void Update()
    {
        
        string viejoEstado = estadoActual.GetName();

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

    			if(s.GetName() == nuevoEstado){

    				estadoActual = s;

    			}

    		}

    	}

    	elEstado = estadoActual.GetName();

    	estadoActual.GetAction();

    }
}
