using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Proyecto
{
    class Aestrella
    {

        public int k = 0;

        public List<Nodo> Ejecutar(Nodo inicio, Nodo final, Grafo grafoActual)
        {

            List<List<double>> heuristicas = new List<List<double>>();
            bool encontrado;

            List<Nodo> camino = new List<Nodo>();

            encontrado = false;
            double g;
            double gNuevo;
            Nodo actual = inicio;
            List<Nodo> caminoAux = new List<Nodo>();

            heuristicas = grafoActual.getHeurtistica();
            List<Nodo> abiertos = new List<Nodo>();
            inicio.SetDistDesdeInicio(0);
            abiertos.Add(inicio);

            List<Nodo> cerrados = new List<Nodo>();

            while(abiertos.Count > 0 && !encontrado)
            {

                Nodo minimo = getMinF(abiertos, grafoActual, final, heuristicas);
                cerrados.Add(minimo);
                abiertos.Remove(minimo);

                if(minimo.Equals(final))
                {
                    encontrado = true;
                    break;

                }
                else
                {

                    List<Nodo> vecinos = minimo.GetAdyacentes;

                    int i = 0;

                    while(i < vecinos.Count)
                        {

                        g = vecinos[i].GetDistDesdeInicio();
                        gNuevo = minimo.GetDistDesdeInicio() + (grafoActual.GetLadoPorNodos(minimo, vecinos[i]).GetPesoLado());

                        if (!cerrados.Contains(vecinos[i]) && !abiertos.Contains(vecinos[i]))
                        {

                            abiertos.Add(vecinos[i]);
                            vecinos[i].SetDistDesdeInicio(gNuevo);
                            vecinos[i].SetPredecesor(minimo);

                        }
                        else
                        {

                            if (gNuevo < g)
                            {

                                vecinos[i].SetDistDesdeInicio(gNuevo);
                                vecinos[i].SetPredecesor(minimo);

                                if (cerrados.Contains(vecinos[i]))
                                {
                                    cerrados.Remove(vecinos[i]);
                                    abiertos.Add(vecinos[i]);

                                }

                            }

                        }

                        i = i + 1;
                    }

                }

            }
            if (!inicio.Equals(final))
            {
                actual = final;

                while (!(actual.GetPredecesor() == null))
                {

                    caminoAux.Add(actual);
                    actual = actual.GetPredecesor();


                }

                caminoAux.Add(inicio);

            }
            else
            {

                caminoAux.Add(inicio);

            }

            for (int i = 0; i < caminoAux.Count; i = i + 1){

                camino.Add(caminoAux[caminoAux.Count - 1 - i]);

            }

            return camino;

        }

        public Nodo getMinF(List<Nodo> abiertos, Grafo grafoActual, Nodo final, List<List<double>> heuristicas)
        {
            int index = 0;
            Nodo nodoDevuelto = abiertos[index];

            if (abiertos.Count > 1)
            {

                foreach (Nodo n in abiertos)
                {

                    if((n.GetDistDesdeInicio() + heuristicas[grafoActual.GetIndiceDe(n)][grafoActual.GetIndiceDe(final)] < nodoDevuelto.GetDistDesdeInicio() + heuristicas[grafoActual.GetIndiceDe(nodoDevuelto)][grafoActual.GetIndiceDe(final)])){

                        nodoDevuelto = n;

                    } 


                }

            }

            return nodoDevuelto;

        }

    }
}
