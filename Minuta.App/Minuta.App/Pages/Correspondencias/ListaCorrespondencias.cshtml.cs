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
    public class ListaCorrespondenciasModel : PageModel
    {
        private readonly IRepositorioCorrespondencia _repoCorrespondencia;

        public IEnumerable<Correspondencia> listaCorrespondencias {get;set;} 

        public ListaCorrespondenciasModel()
        {
            this._repoCorrespondencia = new RepositorioCorrespondencia(new persistencia.AppContext());
        }

        public void OnGet()
        {
            listaCorrespondencias = _repoCorrespondencia.GetAllCorrespondencias();
        }
    }
}