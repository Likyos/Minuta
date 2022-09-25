using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Minuta.App.persistencia;
using Minuta.App.dominio;

namespace Minuta.App.Pages
{
    public class ListarMinutasModel : PageModel
    {
        private readonly IRepositorioMinutaAnotacion _repoMinutaAnotacion;

        public IEnumerable<MinutaAnotacion> listarMinutas {get;set;} 

        public ListarMinutasModel()
        {
            this._repoMinutaAnotacion = new RepositorioMinutaAnotacion(new persistencia.AppContext());
        }

        public void OnGet()
        {
            listarMinutas = _repoMinutaAnotacion.GetAllMAs();
        }
    }
}