
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public interface IRepositorioVehiculo
    {
        IEnumerable<Vehiculo> GetAllVehiculos();
        Vehiculo AddVehiculo(Vehiculo vehiculo);
        Vehiculo GetVehiculo(int idVehiculo);
        Vehiculo UpdateVehiculo(Vehiculo vehiculo);
        void DeleteVehiculo(int idVehiculo);    
        
      //  MinutaAnotacion AsignarMinuta(int idVigilante, int idMinuta); 
    }


}