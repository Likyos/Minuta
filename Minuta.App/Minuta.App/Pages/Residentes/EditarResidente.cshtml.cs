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
    public class EditarResidenteModel : PageModel
    {
        private readonly IRepositorioResidente _repoResidente;
        [BindProperty]
        public Residente residente { get;set; }

        public EditarResidenteModel()
        {
            this._repoResidente = new RepositorioResidente(new persistencia.AppContext());
        }
        public IActionResult OnGet(int? residenteId)
        {
            if (residenteId.HasValue)
            {
                residente = _repoResidente.GetResidente(residenteId.Value);
            }
            else
            {
                residente = new Residente();
            }
            if (residente == null)
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
            if (residente.ID > 0)
            {
                residente = _repoResidente.UpdateResidente(residente);
            }
            else
            {
                _repoResidente.AddResidente(residente);
            }
            return Page();
            
        }
    }
}
