using System;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;
using Microsoft.EntityFrameworkCore;

namespace Minuta.App.persistencia
{

    public class RepositorioResidente : IRepositorioResidente
    {
      
        private readonly AppContext _appContext;
      
        public RepositorioResidente(AppContext appContext)
        {
            _appContext = appContext;
        }


        public Residente AddResidente(Residente residente)
        {
            var ResidenteAdicionado = _appContext.Residentes.Add(residente);
            _appContext.SaveChanges();
            return ResidenteAdicionado.Entity;

        }

       

       public IEnumerable<Residente> GetAllResidentes()
        {
            return GetAllResidentes_();
        }

        public IEnumerable<Residente> GetAllResidentes_()
        {
            return _appContext.Residentes;
        }

        public Residente UpdateResidente(Residente residente)
        {
            var residenteEncontrado = _appContext.Residentes.FirstOrDefault(r => r.ID == residente.ID);
            if (residenteEncontrado != null)
            {
                residenteEncontrado.cedula = residente.cedula;
                residenteEncontrado.nombre = residente.nombre;
                residenteEncontrado.apellido = residente.apellido;
                residenteEncontrado.telefono = residente.telefono;
                residenteEncontrado.idUsuario = residente.idUsuario;
                residenteEncontrado.contrasena = residente.contrasena;
                residenteEncontrado.numApartamento = residente.numApartamento;
                residenteEncontrado.estadoApartamento = residente.estadoApartamento;
                residenteEncontrado.estadoResidente = residente.estadoResidente;
                //vigilanteEncontrado.vehiculo=vigilante.vehiculo.vehiculoID;
               

                _appContext.SaveChanges();
            }
            return residenteEncontrado;
        }

        public void DeleteResidente(int idResidente)
        {
            var residenteEncontrado = _appContext.Residentes.FirstOrDefault(r => r.ID == idResidente);
            if (residenteEncontrado == null)
                return;
            _appContext.Residentes.Remove(residenteEncontrado);
            _appContext.SaveChanges();
        }
        public Residente GetResidente(int idResidente)
        {
            return _appContext.Residentes.FirstOrDefault(r => r.ID == idResidente);
        }

        public Vehiculo AsignarVehiculo(int idResidente, int idVehiculo)
        {
            var ResidenteEncontrado = _appContext.Residentes.FirstOrDefault(m => m.ID == idResidente);
            if (ResidenteEncontrado != null)
            {
                var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(v => v.vehiculoID == idVehiculo);
                if (VehiculoEncontrado != null)
                {
                    ResidenteEncontrado.vehiculo = VehiculoEncontrado;
                    _appContext.SaveChanges();
                }
                return VehiculoEncontrado;
            }
            return null;
        }

    }
}