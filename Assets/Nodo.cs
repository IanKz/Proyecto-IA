using System;
using System.Collections.Generic;

namespace Proyecto
{
    class Nodo
    {

        private Tuple<double, double> primerVertice;
        private Tuple<double, double> segundoVertice;
        private Tuple<double, double> tercerVertice;
        private List<Nodo> adyacentes = new List<Nodo>();
        private Nodo predecesor = null;
        private Nodo sucesor = null;
        private double distDesdeInicio = double.MaxValue;
        private Tuple<double, double> centro;

        public Nodo(Tuple<double, double> v1, Tuple<double, double> v2, Tuple<double, double> v3)
        {

            this.primerVertice = v1;
            this.segundoVertice = v2;
            this.tercerVertice = v3;
            this.centro = new Tuple<double, double>((v1.Item1 + v2.Item1 + v3.Item1) / 3, (v1.Item2 + v2.Item2 + v3.Item2) / 3);

        }

        public Tuple<double, double> GetPrimerVertice() => this.primerVertice;

        public Tuple<double, double> GetSegundoVertice() => this.segundoVertice;

        public Tuple<double, double> GetTercerVertice() => this.tercerVertice;

        public Tuple<double, double> GetCentro => this.centro;

        public List<Nodo> GetAdyacentes => this.adyacentes;

        public void AgregarAdyacente(Nodo nuevoNodo) => GetAdyacentes.Add(nuevoNodo);

        public void EliminarAdyacente(Nodo nodoExistente) => GetAdyacentes.Remove(nodoExistente);

        public bool EsAdyacente(Nodo nodoExistente) => GetAdyacentes.Contains(nodoExistente);

        public void SetPredecesor(Nodo nodoPredecesor) => predecesor = nodoPredecesor;

        public Nodo GetSucesor() => this.sucesor;

        public void SetSucesor(Nodo nodoSucesor) => this.sucesor = nodoSucesor;

        public Nodo GetPredecesor() => this.predecesor;

        public void SetDistDesdeInicio(double i) => distDesdeInicio = i;

        public double GetDistDesdeInicio() => this.distDesdeInicio;

    }
}
