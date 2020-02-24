using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using pc;

namespace Proyecto
{
    class Grafo
    {

        private List<List<double>> heuristics = new List<List<double>>();
        private List<Nodo> nodosEnGrafo = new List<Nodo>();
        private List<Lado> ladosEnGrafo = new List<Lado>();
        private pointChecker pc;

        public Grafo(){

            pc = new pointChecker();
            Nodo nodoAux;
            Nodo nodoAux2;

            for (int i = 0; i < 20; i = i + 2){

                if ((i == 4) || (i == 14)){

                    continue;

                }
                else{

                    for (int j = 0; j < 10; j = j + 2){

                        nodoAux = new Nodo(new Tuple<double, double>((-10 + i), (5 - j)), 
                                           new Tuple<double, double>((-10 + i), (5 - j - 2)), 
                                           new Tuple<double, double>((-10 + i + 2), (5 - j - 2)));

                        nodoAux2 = new Nodo(new Tuple<double, double>((-10 + i), (5 - j)), 
                                           new Tuple<double, double>((-10 + i + 2), (5 - j)), 
                                           new Tuple<double, double>((-10 + i + 2), (5 - j - 2)));

                        this.AgregarNodo(nodoAux);
                        this.AgregarNodo(nodoAux2);

                    }

                }  

            }

            // Con i = 4

            nodoAux = new Nodo(new Tuple<double, double>(-6, 5), 
                      new Tuple<double, double>(-6, 3), 
                      new Tuple<double, double>(-4, 3));
            nodoAux.SetAltura(-1);

            this.AgregarNodo(nodoAux);

            nodoAux = new Nodo(new Tuple<double, double>(-6, 5), 
                       new Tuple<double, double>(-4, 5), 
                       new Tuple<double, double>(-4, 3));
            nodoAux.SetAltura(-1);

            this.AgregarNodo(nodoAux);

            nodoAux = new Nodo(new Tuple<double, double>(-6, -3), 
                      new Tuple<double, double>(-6, -5), 
                      new Tuple<double, double>(-4, -5));
            nodoAux.SetAltura(1);

            this.AgregarNodo(nodoAux);

            nodoAux = new Nodo(new Tuple<double, double>(-6, -3), 
                       new Tuple<double, double>(-4, -3), 
                       new Tuple<double, double>(-4, -5));
            nodoAux.SetAltura(1);

            this.AgregarNodo(nodoAux);

            // con i = 14

            nodoAux = new Nodo(new Tuple<double, double>(4, 5), 
                      new Tuple<double, double>(4, 3), 
                      new Tuple<double, double>(6, 3));
            nodoAux.SetAltura(-1);

            this.AgregarNodo(nodoAux);

            nodoAux = new Nodo(new Tuple<double, double>(4, 5), 
                       new Tuple<double, double>(6, 5), 
                       new Tuple<double, double>(6, 3));
            nodoAux.SetAltura(-1);

            this.AgregarNodo(nodoAux);

            nodoAux = new Nodo(new Tuple<double, double>(4, -3), 
                      new Tuple<double, double>(4, -5), 
                      new Tuple<double, double>(6, -5));
            nodoAux.SetAltura(1);

            this.AgregarNodo(nodoAux);

            nodoAux = new Nodo(new Tuple<double, double>(4, -3), 
                       new Tuple<double, double>(6, -3), 
                       new Tuple<double, double>(6, -5));
            nodoAux.SetAltura(1);

            this.AgregarNodo(nodoAux);

            this.crearLados();

        }

        public void crearLados(){

            List<Nodo> listaNodos = this.GetListaNodos();

            int j = 0;

            foreach (Nodo n1 in listaNodos){

                foreach (Nodo n2 in listaNodos){

                    j = j + 1;

                    if (n2.Equals(n1)){

                        continue;

                    }
                    else if(isLadoInGrafo(n1, n2)){

                        continue;

                    }
                    else{

                        if( (((n1.GetPrimerVertice().Equals(n2.GetPrimerVertice())) || (n1.GetPrimerVertice().Equals(n2.GetSegundoVertice())) || (n1.GetPrimerVertice().Equals(n2.GetTercerVertice()))) &&
                            ((n1.GetSegundoVertice().Equals(n2.GetPrimerVertice())) || (n1.GetSegundoVertice().Equals(n2.GetSegundoVertice())) || (n1.GetSegundoVertice().Equals(n2.GetTercerVertice())))) || 
                            (((n1.GetPrimerVertice().Equals(n2.GetPrimerVertice())) || (n1.GetPrimerVertice().Equals(n2.GetSegundoVertice())) || (n1.GetPrimerVertice().Equals(n2.GetTercerVertice()))) &&
                            ((n1.GetTercerVertice().Equals(n2.GetPrimerVertice())) || (n1.GetTercerVertice().Equals(n2.GetSegundoVertice())) || (n1.GetTercerVertice().Equals(n2.GetTercerVertice())))) ||
                            (((n1.GetSegundoVertice().Equals(n2.GetPrimerVertice())) || (n1.GetSegundoVertice().Equals(n2.GetSegundoVertice())) || (n1.GetSegundoVertice().Equals(n2.GetTercerVertice()))) &&
                            ((n1.GetTercerVertice().Equals(n2.GetPrimerVertice())) || (n1.GetTercerVertice().Equals(n2.GetSegundoVertice())) || (n1.GetTercerVertice().Equals(n2.GetTercerVertice()))))){

                                this.AgregarLado(n1, n2);

                            }

                    }

                }

            }

        }

        public List<Nodo> GetListaNodos()
        {

            return this.nodosEnGrafo;

        }

        public List<Lado> GetListaLados()
        {

            return this.ladosEnGrafo;

        }

        public int LadosEnGrafo()
        {

            return this.ladosEnGrafo.Count;

        }

         public int NodosEnGrafo()
        {

            return this.nodosEnGrafo.Count;

        }
        public void AgregarNodo(Nodo nuevoNodo)
        {
            this.heuristics.Add(new List<double>());
            for (int i = 0; i < (heuristics.Count - 1); i += 1)
            {
                double eDistance = Math.Sqrt((nuevoNodo.GetCentro.Item1 - nodosEnGrafo[i].GetCentro.Item1) * (nuevoNodo.GetCentro.Item1 - nodosEnGrafo[i].GetCentro.Item1)
                    + (nuevoNodo.GetCentro.Item2 - nodosEnGrafo[i].GetCentro.Item2) * (nuevoNodo.GetCentro.Item2 - nodosEnGrafo[i].GetCentro.Item2));
                this.heuristics[heuristics.Count - 1].Add(eDistance);
                this.heuristics[i].Add(eDistance);

            }
            this.heuristics[heuristics.Count - 1].Add(0);
            this.nodosEnGrafo.Add(nuevoNodo);

        }

        public void AgregarNodo(Tuple<double, double> v1, Tuple<double, double> v2, Tuple<double, double> v3)
        {

            Nodo nuevoNodo = new Nodo(v1, v2, v3);
            AgregarNodo(nuevoNodo);

        }

        public void EliminarNodo(Nodo nodoExistente)
        {

            this.nodosEnGrafo.Remove(nodoExistente);

        }

        public void AgregarLado(Lado nuevoLado)
        {

            this.ladosEnGrafo.Add(nuevoLado);

        }

        public void AgregarLado(Nodo nodoInicial, Nodo nodoFinal)
        {

            Lado nuevoLado = new Lado(nodoInicial, nodoFinal);
            this.ladosEnGrafo.Add(nuevoLado);

        }

        public void EliminarLado(Lado ladoExistente)
        {

            this.ladosEnGrafo.Remove(ladoExistente);

        }

        public int GetIndiceDe(Nodo nodoActual)
        {

            int indice = 0;

            foreach (Nodo n in nodosEnGrafo)
            {

                if (n == nodoActual)
                {

                    return indice;

                }

                indice = indice + 1;

            }

            return indice;

        }

        public List<List<double>> getHeurtistica()
        {
            return heuristics;
        }

        public Lado GetLadoPorNodos(Nodo inicio, Nodo final)
        {

            Tuple<double, double> v1 = new Tuple<double, double>(0, 0);
            Tuple<double, double> v2 = new Tuple<double, double>(0, 0);
            Tuple<double, double> v3 = new Tuple<double, double>(0, 0);
            Nodo nodoAux1 = new Nodo(v1, v2, v3);
            Lado ladoAux = new Lado(nodoAux1, nodoAux1);


            foreach (Lado l in GetListaLados())
            {

                if ((l.GetNodoInicial().Equals(inicio) && l.GetNodoFinal().Equals(final)) || (l.GetNodoInicial().Equals(final) && l.GetNodoFinal().Equals(inicio)))
                {

                    return l;

                }

            }

            return ladoAux;

        }

        public bool isLadoInGrafo(Nodo inicio, Nodo final)
        {

            foreach (Lado l in GetListaLados()){

                if ((l.GetNodoInicial().Equals(inicio) && l.GetNodoFinal().Equals(final)) || (l.GetNodoInicial().Equals(final) && l.GetNodoFinal().Equals(inicio))){

                    return true;

                }

            }

            return false;

        }

        public Nodo darNodoContenedor(Vector3 pos){

            Nodo nodoAux = new Nodo(new Tuple<double, double>(0, 0), 
                      new Tuple<double, double>(0, 0), 
                      new Tuple<double, double>(0, 0));;

            foreach(Nodo n in nodosEnGrafo){

                if (pc.isInside(n.GetPrimerVertice(), n.GetSegundoVertice(), n.GetTercerVertice(), pos)){

                    nodoAux = n;
                    break;

                }

            }

            return nodoAux;

        }

    }

}
