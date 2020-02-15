using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto
{
    class Lado
    {

        private Nodo nodoInicial;
        private Nodo nodoFinal;
        private double pesoLado;

        public Lado(Nodo inicio, Nodo fin)
        {

            this.nodoInicial = inicio;
            this.nodoFinal = fin;
            this.pesoLado = Math.Sqrt((inicio.GetPrimerVertice.Item1 - fin.GetPrimerVertice.Item1) * (inicio.GetPrimerVertice.Item1 - fin.GetPrimerVertice.Item1) +
              (inicio.GetPrimerVertice.Item2 - fin.GetPrimerVertice.Item2) * (inicio.GetPrimerVertice.Item2 - fin.GetPrimerVertice.Item2));
            inicio.AgregarAdyacente(fin);
            fin.AgregarAdyacente(inicio);
            inicio.AgregarAdyacente(fin);
            fin.AgregarAdyacente(inicio);

        }

        public Nodo GetNodoInicial() => this.nodoInicial;

        public Nodo GetNodoFinal() => this.nodoFinal;

        public double GetPesoLado() => this.pesoLado;

        public void CambiarPeso(int nuevoPeso)
        {

            this.pesoLado = nuevoPeso;

        }

    }
}
