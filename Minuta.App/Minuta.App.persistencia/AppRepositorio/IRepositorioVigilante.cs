
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public interface IRepositorioVigilante
    {
        IEnumerable<Vigilante> GetAllVigilantes();
        Vigilante AddVigilante(Vigilante vigilante);
        Vigilante UpdateVigilante(Vigilante vigilante);
        void DeleteVigilante(int idVigilante);    
        Vigilante GetVigilante(int idVigilante);
      //  MinutaAnotacion AsignarMinuta(int idVigilante, int idMinuta); 
    }


}