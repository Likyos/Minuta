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
    public class EditarCorrespondenciasModel : PageModel
    {
        private readonly IRepositorioCorrespondencia _repoCorrespondencia;
        private readonly IRepositorioResidente _repoResidente;
        [BindProperty]
        public Correspondencia correspondencia { get; set; }
        public Residente residente { get; set; }
        public IEnumerable<Residente> listaResidente { get; set; }

        public EditarCorrespondenciasModel()
        {
            this._repoCorrespondencia = new RepositorioCorrespondencia(new persistencia.AppContext());
            this._repoResidente = new RepositorioResidente(new persistencia.AppContext());
        }

        public void OnGet(int? correspondenciaId)
        {
            listaResidente = _repoResidente.GetAllResidentes();

            if (correspondenciaId.HasValue)
            {
                correspondencia = _repoCorrespondencia.GetCorrespondencia(correspondenciaId.Value);
            }
            else 
            {
                correspondencia = new Correspondencia();
            }
            if (correspondencia == null)
            {
                RedirectToPage("./NotFound");
            }
                Page();  
        }

        public IActionResult OnPost(Correspondencia correspondencia, int residenteId)
        {
            if (ModelState.IsValid)
            {
                residente = _repoResidente.GetResidente(residenteId);
                if (correspondencia.correspondenciaID > 0)
                {
                    correspondencia.Residente = residente;
                    correspondencia = _repoCorrespondencia.UpdateCorrespondencia(correspondencia);
                }
                else
                {
                    
                    correspondencia = _repoCorrespondencia.AddCorrespondencia(correspondencia);
                    _repoCorrespondencia.AsignarResidente(correspondencia.correspondenciaID,residente.ID);
                }
                return RedirectToPage("/Correspondencias/ListaCorrespondencias");

            }
            else
            {
               return Page();
            }
        }
    }
}
