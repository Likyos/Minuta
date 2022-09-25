using System;

namespace Minuta.App.dominio
{
    public class Visitor : Persona
    {
        public string motivoVisita {get; set;}     
        public Vehiculo vehiculo{get; set;} = null!;
    }
}
