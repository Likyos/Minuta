using System;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;
using Microsoft.EntityFrameworkCore;

namespace Minuta.App.persistencia
{

    public class RepositorioVehiculo : IRepositorioVehiculo
    {
      
        private readonly AppContext _appContext;
      
        public RepositorioVehiculo(AppContext appContext)
        {
            _appContext = appContext;
        }


        public Vehiculo AddVehiculo(Vehiculo vehiculo)
        {
            var VehiculoAdicionado = _appContext.Vehiculos.Add(vehiculo);
            _appContext.SaveChanges();
            return VehiculoAdicionado.Entity;

        }

       

       public IEnumerable<Vehiculo> GetAllVehiculos()
        {
            return GetAllVehiculos_();
        }

        public IEnumerable<Vehiculo> GetAllVehiculos_()
        {
            return _appContext.Vehiculos;
        }

        public Vehiculo UpdateVehiculo(Vehiculo vehiculo)
        {
            var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(ve => ve.vehiculoID == vehiculo.vehiculoID);
            if (VehiculoEncontrado != null)
            {
                VehiculoEncontrado.tipoVehiculo = vehiculo.tipoVehiculo;
                VehiculoEncontrado.placaVehiculo = vehiculo.placaVehiculo;
               

                _appContext.SaveChanges();
            }
            return VehiculoEncontrado;
        }

        public void DeleteVehiculo(int idVehiculo)
        {
            var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(ve => ve.vehiculoID == idVehiculo);
            if (VehiculoEncontrado == null)
                return;
            _appContext.Vehiculos.Remove(VehiculoEncontrado);
            _appContext.SaveChanges();
        }
        public Vehiculo GetVehiculo(int idVehiculo)
        {
            return _appContext.Vehiculos.FirstOrDefault(ve => ve.vehiculoID == idVehiculo);
        }

    }
}