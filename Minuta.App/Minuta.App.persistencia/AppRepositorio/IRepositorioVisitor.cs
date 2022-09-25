
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public interface IRepositorioVisitor
    {
        IEnumerable<Visitor> GetAllVisitors();
        Visitor AddVisitor(Visitor visitor);           
        Visitor GetVisitor(int idVisitor);
        Vehiculo AsignarVehiculo(int idVisitante, int idVehiculo);
    }
}