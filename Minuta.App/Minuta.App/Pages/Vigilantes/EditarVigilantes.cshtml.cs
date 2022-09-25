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
    public class EditarVigilantesModel : PageModel
    {
        private readonly IRepositorioVigilante _repoVigilante;
        [BindProperty]
        public Vigilante vigilante { get;set; }

        public EditarVigilantesModel()
        {
            this._repoVigilante = new RepositorioVigilante(new persistencia.AppContext());
        }
        public IActionResult OnGet(int? vigilanteId)
        {
            if (vigilanteId.HasValue)
            {
                vigilante = _repoVigilante.GetVigilante(vigilanteId.Value);
            }
            else
            {
                vigilante = new Vigilante();
            }
            if (vigilante == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
            
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (vigilante.ID > 0)
            {
                vigilante = _repoVigilante.UpdateVigilante(vigilante);
            }
            else
            {
                _repoVigilante.AddVigilante(vigilante);
            }
            return Page();
            
        }
    }
}
