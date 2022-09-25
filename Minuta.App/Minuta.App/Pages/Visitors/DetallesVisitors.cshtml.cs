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
    public class DetallesVisitorsModel : PageModel
    {
        private readonly IRepositorioVisitor _repoVisitor;
        public Visitor visitor {get;set;}
        public DetallesVisitorsModel()
        {
            this._repoVisitor = new RepositorioVisitor(new persistencia.AppContext()); 
        }
        public IActionResult OnGet(int visitorId)
        {
            visitor = _repoVisitor.GetVisitor(visitorId);
            if (visitor == null)
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

