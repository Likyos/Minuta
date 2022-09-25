using System;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;
using Microsoft.EntityFrameworkCore;

namespace Minuta.App.persistencia
{

    public class RepositorioMinutaAnotacion : IRepositorioMinutaAnotacion
    {
      
        private readonly AppContext _appContext;
      
        public RepositorioMinutaAnotacion(AppContext appContext)
        {
            _appContext = appContext;
        }


        public MinutaAnotacion AddMA(MinutaAnotacion minutaAnotacion)
        {
            var MAAdicionado = _appContext.MinutaAnotaciones.Add(minutaAnotacion);
            _appContext.SaveChanges();
            return MAAdicionado.Entity;

        }       

        public IEnumerable<MinutaAnotacion> GetAllMAs()
        {
            return _appContext.MinutaAnotaciones;
        }

        public Vigilante AsignarVigilante(int idMinuta, int idVigilante)
        {
            var MinutaEncontrado = _appContext.MinutaAnotaciones.FirstOrDefault(m => m.minutaAnotacionID == idMinuta);
            if (MinutaEncontrado != null)
            {
                var VigilanteEncontrado = _appContext.Vigilantes.FirstOrDefault(v => v.ID == idVigilante);
                if (VigilanteEncontrado != null)
                {
                    MinutaEncontrado.vigilante = VigilanteEncontrado;
                    _appContext.SaveChanges();
                }
                return VigilanteEncontrado;
            }
            return null;
        }

        public MinutaAnotacion GetMinutaAnotacion(int idMinutaAnotacion)
        {
            return _appContext.MinutaAnotaciones.FirstOrDefault(r => r.minutaAnotacionID == idMinutaAnotacion);
        }

        public MinutaAnotacion UpdateMinutaAnotacion(MinutaAnotacion minutaAnotacion)
        {
            var MinutaEncontrado = _appContext.MinutaAnotaciones.FirstOrDefault(c => c.minutaAnotacionID == minutaAnotacion.minutaAnotacionID);
            if (MinutaEncontrado != null)
            {
                MinutaEncontrado.asunto = minutaAnotacion.asunto;
                //vigilanteEncontrado.vehiculo=vigilante.vehiculo.vehiculoID;
               

                _appContext.SaveChanges();
            }
            return MinutaEncontrado;
        }

    }
}