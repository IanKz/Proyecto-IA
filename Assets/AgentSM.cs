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
    public GameObject goal;
    public Agent aux;
	Vector3 inicio;
	List<State> estados;
	Transition transicionDisparada;
	State estadoActual;

    // Start is called before the first frame update
    void Start()
    {

    	GameObject go = new GameObject();
    	go.transform.position = meta;
    	Agent ag = go.AddComponent<Agent>() as Agent;

        inicio = yo.transform.position;
    	GameObject go1 = new GameObject();
    	go1.transform.position = inicio;
    	Agent ag1 = go1.AddComponent<Agent>() as Agent;
        
    	estados = new List<State>();

    	List<Transition> buscandoTrans = new List<Transition>(); 
    	buscandoTrans.Add(new waitingForFoodTrans(otro1, otro2, "Esperando"));
    	buscandoTrans.Add(new tookFoodTrans(yo, ag, "Cargado"));
    	ChaseState fs = new ChaseState(yo, ag, buscandoTrans, maxA);
    	fs.SetName("Buscando");
    	estados.Add(fs);

    	List<Transition> cargadoTrans = new List<Transition>();
    	cargadoTrans.Add(new depositadoTrans(yo, ag1, "Buscando"));
        cargadoTrans.Add(new intersectadoTrans(yo, "Buscando"));
    	cargadoState ss = new cargadoState(yo, ag1, cargadoTrans, maxA);
    	ss.SetName("Cargado");
    	estados.Add(ss);

    	List<Transition> esperandoTrans = new List<Transition>();
    	esperandoTrans.Add(new disponibleTrans(yo, otro1, otro2, "Buscando"));
    	esperandoState ts = new esperandoState(esperandoTrans);
    	ts.SetName("Esperando");
    	estados.Add(ts);

    	estadoActual = fs;

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

    		if(nuevoEstado == "Cargado"){
                goal.SetActive(false);
    			yo.cargado = true;

    		}
            else if (nuevoEstado == "Buscando"){

                if(viejoEstado == "Cargado"){

                    goal.SetActive(true);

                }

                yo.cargado = false;

            }

    	}

    	elEstado = estadoActual.GetName();

    	estadoActual.GetAction();

    }
}
