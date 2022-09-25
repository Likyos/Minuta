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
    public class ListaResidenteModel : PageModel
    {
        private readonly IRepositorioResidente _repoResidente;
        
        public IEnumerable<Residente> listaResidente {get;set;} 

        public ListaResidenteModel()
        {
            this._repoResidente = new RepositorioResidente(new persistencia.AppContext());
        }
        
        public void OnGet()
        {
            listaResidente = _repoResidente.GetAllResidentes();
        }
    }
}