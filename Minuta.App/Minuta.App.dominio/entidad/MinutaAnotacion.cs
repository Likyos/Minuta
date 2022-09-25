using System;

namespace Minuta.App.dominio
{
    public class MinutaAnotacion
    {
        public  int minutaAnotacionID {get; set;}
        public  DateTime fechaAnotacion {get; set;}
        public string asunto {get; set;}        
        public Vigilante vigilante{get; set;}
    }
}
