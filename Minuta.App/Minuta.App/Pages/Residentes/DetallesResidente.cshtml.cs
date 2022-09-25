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
    public class DetallesResidenteModel : PageModel
    {
    private readonly IRepositorioResidente _repoResidente;
        public Residente residente {get;set;}
        public DetallesResidenteModel()
        {
            this._repoResidente = new RepositorioResidente(new persistencia.AppContext()); 
        }
        public IActionResult OnGet(int residenteId)
        {
            residente = _repoResidente.GetResidente(residenteId);
            if (residente == null)
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
