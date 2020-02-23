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
	List<Nodo> camino;
	pointChecker pc;
	int actual;
	Vector3 ubicacionActual = Vector3.zero;
	Vector3 actualPosition;
	dSeekComp dsc;
    dArriveComp dac;
	Vector3 targetPos = Vector3.zero;
    bool arrived;
    double maxS = 100;
    double slowR = 0.3;
    double targetR = 0.1;
    double timeToT = 0.1;


    public seekUsingGraphComp(Agent agente, Agent objetivo, double max){

    	agent = agente;
    	target = objetivo;
    	maxA = max;
        grafoActual = new Grafo();
        grafoActual.crearLados();
        A = new Aestrella();
        camino = new List<Nodo>();
        pc = new pointChecker();
        arrived = false;
        
    	actual = 0;

    }

    public void DoYourThing(){

        Nodo partida = grafoActual.darNodoContenedor(agent.transform.position);
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

        if (arrived){

            if (!partida.Equals(destino)){

                arrived = false;

            }
            else{

                dac = new dArriveComp(agent, target.transform.position, maxA, maxS, targetR, slowR, timeToT);
                dac.doYourThing();

            }

        }

        if(camino.Count <= actual){

            actual = 0;

        }

        if ((agent.transform.position.x - 0.2 <= camino[actual].GetCentro.Item1 && camino[actual].GetCentro.Item1 <= agent.transform.position.x + 0.2) && 
            (agent.transform.position.y - 0.2 <= camino[actual].GetCentro.Item2 && camino[actual].GetCentro.Item2 <= agent.transform.position.y + 0.2) &&
            actual != (camino.Count - 1)){
            actual = actual + 1;
        }

        if(camino.Count <= actual){

            actual = 0;

        }

        if(partida.Equals(destino)){

            dac = new dArriveComp(agent, target.transform.position, maxA, maxS, targetR, slowR, timeToT);
            dac.doYourThing();
        //    dsc = new dSeekComp(agent, target.transform.position, maxA, Vector3.zero);
        //    dsc.doYourThing();
            arrived = true;

        }
        else{

                Vector3 objetivoActual = new Vector3((float)camino[actual].GetCentro.Item1, (float)camino[actual].GetCentro.Item2, 0);

                dac = new dArriveComp(agent, objetivoActual, maxA, maxS, targetR, slowR, timeToT);
                dac.doYourThing();

        }


    }

}
