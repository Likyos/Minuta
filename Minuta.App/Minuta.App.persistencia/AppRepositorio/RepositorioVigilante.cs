using System;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;
using Microsoft.EntityFrameworkCore;

namespace Minuta.App.persistencia
{

    public class RepositorioVigilante : IRepositorioVigilante
    {
      
        private readonly AppContext _appContext;
      
        public RepositorioVigilante(AppContext appContext)
        {
            _appContext = appContext;
        }


        public Vigilante AddVigilante(Vigilante vigilante)
        {
            var VigilanteAdicionado = _appContext.Vigilantes.Add(vigilante);
            _appContext.SaveChanges();
            return VigilanteAdicionado.Entity;

        }

       

       public IEnumerable<Vigilante> GetAllVigilantes()
        {
            return GetAllVigilantes_();
        }

        public IEnumerable<Vigilante> GetAllVigilantes_()
        {
            return _appContext.Vigilantes;
        }

        public Vigilante UpdateVigilante(Vigilante vigilante)
        {
            var vigilanteEncontrado = _appContext.Vigilantes.FirstOrDefault(v => v.ID == vigilante.ID);
            if (vigilanteEncontrado != null)
            {
                vigilanteEncontrado.cedula = vigilante.cedula;
                vigilanteEncontrado.nombre = vigilante.nombre;
                vigilanteEncontrado.apellido = vigilante.apellido;
                vigilanteEncontrado.telefono = vigilante.telefono;
                vigilanteEncontrado.idUsuario = vigilante.idUsuario;
                vigilanteEncontrado.contrasena = vigilante.contrasena;
                vigilanteEncontrado.placaVigilante = vigilante.placaVigilante;
                               

                _appContext.SaveChanges();
            }
            return vigilanteEncontrado;
        }

        public void DeleteVigilante(int idVigilante)
        {
            var vigilanteEncontrado = _appContext.Vigilantes.FirstOrDefault(v => v.ID == idVigilante);
            if (vigilanteEncontrado == null)
                return;
            _appContext.Vigilantes.Remove(vigilanteEncontrado);
            _appContext.SaveChanges();
        }
        public Vigilante GetVigilante(int idVigilante)
        {
            return _appContext.Vigilantes.FirstOrDefault(m => m.ID == idVigilante);
        }
    }
}