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
    public class EditarVisitorsModel : PageModel
    {
        private readonly IRepositorioVisitor _repoVisitor;
        [BindProperty]
        public Visitor visitor { get;set; }

        public EditarVisitorsModel()
        {
            this._repoVisitor = new RepositorioVisitor(new persistencia.AppContext());
        }
        public IActionResult OnGet(int? visitorId)
        {
            if (visitorId.HasValue)
            {
                visitor = _repoVisitor.GetVisitor(visitorId.Value);
            }
            else
            {
                visitor = new Visitor();
            }
            if (visitor == null)
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
            else
            {
                _repoVisitor.AddVisitor(visitor);
            }
            return Page();
            
        }
        
    }
}

