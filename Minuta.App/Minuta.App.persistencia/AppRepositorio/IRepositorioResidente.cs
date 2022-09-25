
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public interface IRepositorioResidente
    {
        IEnumerable<Residente> GetAllResidentes();
        Residente AddResidente(Residente residente);
        Residente UpdateResidente(Residente residente);
        void DeleteResidente(int idResidente);    
        Residente GetResidente(int idResidente);
        
        Vehiculo AsignarVehiculo(int idResidente, int idVehiculo);
      //  MinutaAnotacion AsignarMinuta(int idVigilante, int idMinuta); 
    }


}