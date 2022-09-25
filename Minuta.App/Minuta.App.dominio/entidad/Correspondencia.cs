using System;

namespace Minuta.App.dominio
{
    public class Correspondencia
    {
        public  int correspondenciaID {get; set;}
        public  string tipoCorrespondencia {get; set;}
        public string remitente {get; set;}
        public string estadoEntrega {get; set;}
        public Residente Residente {get; set;}
    }
}
