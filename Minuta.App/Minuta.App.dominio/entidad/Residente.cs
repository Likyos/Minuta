using System;

namespace Minuta.App.dominio
{
    public class Residente : UserAdmin
    {
        public int numApartamento {get; set;}
        public string estadoApartamento {get; set;}
        public string estadoResidente {get; set;}
        public Vehiculo vehiculo{get; set;}= null!;
    }
}
