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

            Console.WriteLine(grafoActual.GetListaLados());

        }

    }

}
