
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public interface IRepositorioCorrespondencia
    {
        IEnumerable<Correspondencia> GetAllCorrespondencias();
        Correspondencia AddCorrespondencia(Correspondencia correspondencia);        
        Correspondencia UpdateCorrespondencia(Correspondencia correspondencia);
        Correspondencia GetCorrespondencia(int idCorrespondencia);
        Residente AsignarResidente(int idCorrespondencia, int idResidente);
        
    }
}