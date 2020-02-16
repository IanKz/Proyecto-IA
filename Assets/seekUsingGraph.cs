using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto;
using pc;

public class seekUsingGraph : MonoBehaviour
{

	private Vector3 ubicacionActual = Vector3.zero;
	public Agent agent;
	public Agent target;
	private Grafo grafoActual;
	private Aestrella A;
	private List<Nodo> camino;
	Vector3 actualPosition;
	pointChecker pc;
	dSeekComp dsc;
	Agent agentAux;
	public double maxA;
	Vector3 targetPos = Vector3.zero;
	Nodo destino;
	Nodo partida;
	int actual = 0;

    // Start is called before the first frame update
    void Start()
    {

        grafoActual = new Grafo();
        grafoActual.crearLados();
        A = new Aestrella();
        camino = new List<Nodo>();
        pc = new pointChecker();
        agentAux = new Agent();

        foreach (Nodo n in grafoActual.GetListaNodos()){

        	if (pc.isInside(n.GetPrimerVertice(), n.GetSegundoVertice(), n.GetTercerVertice(), target.transform.position)){
        		destino = n;
        		break;

        	}

        }

        foreach (Nodo m in grafoActual.GetListaNodos()){

        	if (pc.isInside(m.GetPrimerVertice(), m.GetSegundoVertice(), m.GetTercerVertice(), agent.transform.position)){
        		partida = m;
        		break;

        	}

        }

        camino = A.Ejecutar(partida, destino, grafoActual);
        actual = camino.Count - 1;
        
    }

    // Update is called once per frame
    void Update()
    {

    	if ((agent.transform.position.x - 0.2<= camino[actual].GetCentro.Item1 && camino[actual].GetCentro.Item1 <= agent.transform.position.x + 0.2) && 
    		(agent.transform.position.y - 0.2 <= camino[actual].GetCentro.Item2 && camino[actual].GetCentro.Item2 <= agent.transform.position.y + 0.2) &&
    		actual != 0){
    		actual = actual - 1;
    	}

    	if(actual == 0){

    		dsc = new dSeekComp(agent, target.transform.position, maxA, Vector3.zero);
    		dsc.doYourThing();

    	}
    	else{

	    	Vector3 objetivoActual = new Vector3((float)camino[actual].GetCentro.Item1, (float)camino[actual].GetCentro.Item2, 0);

	        dsc = new dSeekComp(agent, objetivoActual, maxA, objetivoActual);
	        dsc.doYourThing();

    	}

	}
}
