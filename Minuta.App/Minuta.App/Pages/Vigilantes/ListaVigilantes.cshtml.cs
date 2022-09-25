using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Minuta.App.dominio;
using Minuta.App.persistencia;

namespace Minuta.App.Pages
{
    public class ListaVigilantesModel : PageModel
    {
        private readonly IRepositorioVigilante _repoVigilante;
        
        public IEnumerable<Vigilante> listaVigilante {get;set;} 

        public ListaVigilantesModel()
        {
            this._repoVigilante = new RepositorioVigilante(new persistencia.AppContext());
        }
        
        public void OnGet()
        {
            listaVigilante = _repoVigilante.GetAllVigilantes();
        }
    }
}
