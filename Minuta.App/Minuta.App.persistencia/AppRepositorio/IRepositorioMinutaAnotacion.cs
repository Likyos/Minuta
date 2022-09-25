
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public interface IRepositorioMinutaAnotacion
    {
        IEnumerable<MinutaAnotacion> GetAllMAs();
        MinutaAnotacion AddMA(MinutaAnotacion minutaAnotacion);
        MinutaAnotacion GetMinutaAnotacion(int idMinutaAnotacion);        
        MinutaAnotacion UpdateMinutaAnotacion(MinutaAnotacion minutaAnotacion);
        Vigilante AsignarVigilante(int idMinuta, int idVigilante);
        
    }


}