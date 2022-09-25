using System;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;
using Microsoft.EntityFrameworkCore;

namespace Minuta.App.persistencia
{

    public class RepositorioVisitor : IRepositorioVisitor
    {
      /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioVisitor(AppContext appContext)
        {
            _appContext = appContext;
        }


        public Visitor AddVisitor(Visitor visitor)
        {
            var visitorAdicionado = _appContext.Visitors.Add(visitor);
            _appContext.SaveChanges();
            return visitorAdicionado.Entity;

        }       

       public IEnumerable<Visitor> GetAllVisitors()
        {
            return _appContext.Visitors;
        }

        public Vehiculo AsignarVehiculo(int idVisitor, int idVehiculo)
        {
            var VisitorEncontrado = _appContext.Visitors.FirstOrDefault(m => m.ID == idVisitor);
            if (VisitorEncontrado != null)
            {
                var VehiculoEncontrado = _appContext.Vehiculos.FirstOrDefault(v => v.vehiculoID == idVehiculo);
                if (VehiculoEncontrado != null)
                {
                    VisitorEncontrado.vehiculo = VehiculoEncontrado;
                    _appContext.SaveChanges();
                }
                return VehiculoEncontrado;
            }
            return null;
        }

        public Visitor GetVisitor(int idVisitor)
        {
            return _appContext.Visitors.FirstOrDefault(m => m.ID == idVisitor);
        }
    }
}