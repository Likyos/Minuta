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
    public class DetallesCorrespondenciasModel : PageModel
    {
        private readonly IRepositorioCorrespondencia _repoCorrespondencia;
        public Correspondencia correspondencia {get;set;}
        public DetallesCorrespondenciasModel()
        {
            this._repoCorrespondencia = new RepositorioCorrespondencia(new persistencia.AppContext()); 
        }
        public IActionResult OnGet(int correspondenciaId)
        {
            correspondencia = _repoCorrespondencia.GetCorrespondencia(correspondenciaId);
            if (correspondencia == null)
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