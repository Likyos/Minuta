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
    public class ListaVisitorsModel : PageModel
    {
        private readonly IRepositorioVisitor _repoVisitor;
        
        public IEnumerable<Visitor> listaVisitor {get;set;} 

        public ListaVisitorsModel()
        {
            this._repoVisitor = new RepositorioVisitor(new persistencia.AppContext());
        }
        
        public void OnGet()
        {
            listaVisitor = _repoVisitor.GetAllVisitors();
        }
    }
}
