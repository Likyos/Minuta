using System;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;
using Microsoft.EntityFrameworkCore;

namespace Minuta.App.persistencia
{

    public class RepositorioCorrespondencia : IRepositorioCorrespondencia
    {    /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioCorrespondencia(AppContext appContext)
        {
            _appContext = appContext;
        }
        public Correspondencia AddCorrespondencia(Correspondencia correspondencia)
        {
            var CorrespondenciaAdicionado = _appContext.Correspondencias.Add(correspondencia);
            _appContext.SaveChanges();
            return CorrespondenciaAdicionado.Entity;

        }

        public Correspondencia UpdateCorrespondencia(Correspondencia correspondencia)
        {
            var CorrespondenciaEncontrado = _appContext.Correspondencias.FirstOrDefault(c => c.correspondenciaID == correspondencia.correspondenciaID);
            if (CorrespondenciaEncontrado != null)
            {
                CorrespondenciaEncontrado.estadoEntrega = correspondencia.estadoEntrega;
                //vigilanteEncontrado.vehiculo=vigilante.vehiculo.vehiculoID;
               

                _appContext.SaveChanges();
            }
            return CorrespondenciaEncontrado;
        }

        public Correspondencia GetCorrespondencia(int idCorrespondencia)
        {
            return _appContext.Correspondencias.FirstOrDefault(c => c.correspondenciaID == idCorrespondencia);
        }
        // lista correspondencias
        public IEnumerable<Correspondencia> GetAllCorrespondencias()
        {
            return _appContext.Correspondencias;
        }
        // asigna Residente a la correspondencia
        public Residente AsignarResidente(int idC, int idR)
        {
            var cEncontrado = _appContext.Correspondencias.FirstOrDefault(m => m.correspondenciaID == idC);
            if (cEncontrado != null)
            {
                var rEncontrado = _appContext.Residentes.FirstOrDefault(v => v.ID == idR);
                if (rEncontrado != null)
                {
                    cEncontrado.Residente = rEncontrado;
                    _appContext.SaveChanges();
                }
                return rEncontrado;
            }
            return null;
        }

    }
}