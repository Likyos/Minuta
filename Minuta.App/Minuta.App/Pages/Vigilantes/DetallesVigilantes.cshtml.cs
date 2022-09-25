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
    public class DetallesVigilantesModel : PageModel
    {
        private readonly IRepositorioVigilante _repoVigilante;
        public Vigilante vigilante {get;set;}
        public DetallesVigilantesModel()
        {
            this._repoVigilante = new RepositorioVigilante(new persistencia.AppContext()); 
        }
        public IActionResult OnGet(int vigilanteId)
        {
            vigilante = _repoVigilante.GetVigilante(vigilanteId);
            if (vigilante == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}

