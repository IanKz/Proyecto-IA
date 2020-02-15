using System;
using System.Collections.Generic;

namespace Proyecto
{

    class Prueba
    {

        static void Main(string[] args)
        {
            Grafo grafoActual = new Grafo();
            Aestrella A = new Aestrella();
            List<Nodo> camino = new List<Nodo>();

            Tuple<double, double> v1 = new Tuple<double, double>(-9, 5);
            Tuple<double, double> v2 = new Tuple<double, double>(-9, 3);
            Tuple<double, double> v3 = new Tuple<double, double>(-7, 3);

            Tuple<double, double> v4 = new Tuple<double, double>(-9, 5);
            Tuple<double, double> v5 = new Tuple<double, double>(-7, 5);
            Tuple<double, double> v6 = new Tuple<double, double>(-7, 3);

            Nodo nodoAux1 = new Nodo(v1, v2, v3);
            Nodo nodoAux2 = new Nodo(v4, v5, v6);

            Lado laduAux = new Lado(nodoAux1, nodoAux2);

            grafoActual.agregarLado(ladoAux);

            Tuple<double, double> v1 = new Tuple<double, double>(-7, 5);
            Tuple<double, double> v2 = new Tuple<double, double>(-7, 3);
            Tuple<double, double> v3 = new Tuple<double, double>(-5, 3);

            Tuple<double, double> v4 = new Tuple<double, double>(-7, 5);
            Tuple<double, double> v5 = new Tuple<double, double>(-5, 5);
            Tuple<double, double> v6 = new Tuple<double, double>(-5, 3);

            Nodo nodoAux3 = new Nodo(v1, v2, v3);
            Nodo nodoAux4 = new Nodo(v4, v5, v6);

            laduAux = new Lado(nodoAux2, nodoAux3);
            grafoActual.agregarLado(ladoAux);

            laduAux = new Lado(nodoAux3, nodoAux4);
            grafoActual.agregarLado(ladoAux);

            Tuple<double, double> v1 = new Tuple<double, double>(-9, 3);
            Tuple<double, double> v2 = new Tuple<double, double>(-9, 1);
            Tuple<double, double> v3 = new Tuple<double, double>(-7, 1);

            Tuple<double, double> v4 = new Tuple<double, double>(-9, 3);
            Tuple<double, double> v5 = new Tuple<double, double>(-7, 3);
            Tuple<double, double> v6 = new Tuple<double, double>(-7, 1);

            Nodo nodoAux5 = new Nodo(v1, v2, v3);
            Nodo nodoAux6 = new Nodo(v4, v5, v6);

            ladoAux = new Lado(nodoAux5, nodoAux6);
            grafoActual.agregarLado(ladoAux);

            ladoAux = new Lado(nodoAux1, nodoAux6);
            grafoActual.agregarLado(ladoAux);

            Tuple<double, double> v1 = new Tuple<double, double>(-7, 3);
            Tuple<double, double> v2 = new Tuple<double, double>(-7, 1);
            Tuple<double, double> v3 = new Tuple<double, double>(-5, 1);

            Tuple<double, double> v4 = new Tuple<double, double>(-7, 3);
            Tuple<double, double> v5 = new Tuple<double, double>(-5, 3);
            Tuple<double, double> v6 = new Tuple<double, double>(-5, 1);

            Nodo nodoAux7 = new Nodo(v1, v2, v3);
            Nodo nodoAux8 = new Nodo(v4, v5, v6);

            ladoAux = new Lado(nodoAux7, nodoAux8);
            grafoActual.agregarLado(ladoAux);

            ladoAux = new Lado(nodoAux3, nodoAux8);
            grafoActual.agregarLado(ladoAux);

            ladoAux = new Lado(nodoAux6, nodoAux);
            grafoActual.agregarLado(ladoAux);


            camino = A.Ejecutar(nodoAux2, nodoAux7, grafoActual);

            for (int i = 0; i < camino.Count; i++)
            {

                Console.WriteLine(camino[i].GetNombre);

            }

        }

    }

}
