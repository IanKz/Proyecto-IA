using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto;
using pc;
using UnityEditor;

public class seekUsingGraphComp
{

	Agent agent;
	Agent target;
	double maxA;
	Grafo grafoActual;
	Aestrella A;
	Nodo partida;
	List<Nodo> camino;
	pointChecker pc;
	int actual;
	Vector3 ubicacionActual = Vector3.zero;
	Vector3 actualPosition;
	dSeekComp dsc;
	Vector3 targetPos = Vector3.zero;


    public seekUsingGraphComp(Agent agente, Agent objetivo, double max){

    	agent = agente;
    	target = objetivo;
    	maxA = max;
        grafoActual = new Grafo();
        grafoActual.crearLados();
        A = new Aestrella();
        camino = new List<Nodo>();
        pc = new pointChecker();
        partida = grafoActual.darNodoContenedor(agent.transform.position);
    	actual = 0;

    }

    public void DoYourThing(){

        Nodo destino = grafoActual.darNodoContenedor(target.transform.position);

        camino = A.Ejecutar(partida, destino, grafoActual);
        for (int j = 0; j < (camino.Count - 1); j = j + 1){

            Debug.DrawLine(new Vector3((float)camino[j].GetCentro.Item1, (float)camino[j].GetCentro.Item2, 0),
                            new Vector3((float)camino[j+1].GetCentro.Item1, (float)camino[j+1].GetCentro.Item2, 0));

        }

        foreach (Nodo n in grafoActual.GetListaNodos()){

            Debug.DrawLine(new Vector3((float)n.GetPrimerVertice().Item1, (float)n.GetPrimerVertice().Item2, 0),
                            new Vector3((float)n.GetSegundoVertice().Item1, (float)n.GetSegundoVertice().Item2, 0));

            Debug.DrawLine(new Vector3((float)n.GetSegundoVertice().Item1, (float)n.GetSegundoVertice().Item2, 0),
                            new Vector3((float)n.GetTercerVertice().Item1, (float)n.GetTercerVertice().Item2, 0));

            Debug.DrawLine(new Vector3((float)n.GetPrimerVertice().Item1, (float)n.GetPrimerVertice().Item2, 0),
                            new Vector3((float)n.GetTercerVertice().Item1, (float)n.GetTercerVertice().Item2, 0));

        }

        if(camino.Count <= actual){

            actual = camino.Count - 1;

        }

        if ((agent.transform.position.x - 0.2 <= camino[actual].GetCentro.Item1 && camino[actual].GetCentro.Item1 <= agent.transform.position.x + 0.2) && 
            (agent.transform.position.y - 0.2 <= camino[actual].GetCentro.Item2 && camino[actual].GetCentro.Item2 <= agent.transform.position.y + 0.2) &&
            actual != (camino.Count - 1)){
            actual = actual + 1;
        }

        if(actual == (camino.Count - 1)){

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
