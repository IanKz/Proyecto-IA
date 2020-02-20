using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSM : MonoBehaviour
{

	public Agent yo;
	public Agent otro1;
	public Agent otro2;
	public double maxA;
	public Vector3 meta;
	public string elEstado;
	Vector3 inicio;
	List<State> estados;
	Transition transicionDisparada;
	State estadoActual;

    // Start is called before the first frame update
    void Start()
    {

    	inicio = yo.transform.position;
        
    	estados = new List<State>();

    	List<Transition> buscandoTrans = new List<Transition>(); 
    	buscandoTrans.Add(new waitingForFoodTrans(yo, otro1, otro2, "Esperando"));
    	buscandoTrans.Add(new tookFoodTrans(yo, meta, "Cargado"));
    	ChaseState cfs = new ChaseState(meta, yo, buscandoTrans, maxA);
    	cfs.SetName("Buscando");
    	estados.Add(cfs);

    	List<Transition> cargadoTrans = new List<Transition>();
    	cargadoTrans.Add(new depositadoTrans(yo, inicio, "Buscando"));
    	cargadoState css = new cargadoState(yo, inicio, cargadoTrans, maxA);
    	css.SetName("Cargado");
    	estados.Add(css);

    	List<Transition> esperandoTrans = new List<Transition>();
    	esperandoTrans.Add(new depositadoTrans(yo, inicio, "Buscando"));
    	esperandoState cts = new esperandoState(yo, esperandoTrans);
    	cts.SetName("Esperando");
    	estados.Add(cts);

    	estadoActual = cfs;

    }

    // Update is called once per frame
    void Update()
    {
        
    	Debug.Log("El estado actual es: " + estadoActual.GetName());

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

    			Debug.Log("Mi estado es: " + s.GetName() + " el nuevo estado es: " + nuevoEstado + " y mi nombre es: " + yo.name);

    			if(s.GetName() == nuevoEstado){

    				estadoActual = s;

    			}

    		}

    	}
    	elEstado = estadoActual.GetName();

    	estadoActual.GetAction();

    }
}
