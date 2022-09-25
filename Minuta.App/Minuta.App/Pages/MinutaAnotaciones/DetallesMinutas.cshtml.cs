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
    public class DetallesMinutasModel : PageModel
    {
        private readonly IRepositorioMinutaAnotacion _repoMA;
        public MinutaAnotacion minutaAnotacion {get;set;}
        public DetallesMinutasModel()
        {
            this._repoMA = new RepositorioMinutaAnotacion(new persistencia.AppContext()); 
        }
        public IActionResult OnGet(int minutaAnotacionId)
        {
            minutaAnotacion = _repoMA.GetMinutaAnotacion(minutaAnotacionId);
            if (minutaAnotacion == null)
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