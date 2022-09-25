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
    public class EditarMinutasModel : PageModel
    {
        private readonly IRepositorioMinutaAnotacion _repoMinutaAnotacion;
        private readonly IRepositorioVigilante _repoVigilante;
        [BindProperty]
        public MinutaAnotacion minutaAnotacion { get; set; }
        public Vigilante vigilante { get; set; }
        public IEnumerable<Vigilante> listaVigilante { get; set; }

        public EditarMinutasModel()
        {
            this._repoMinutaAnotacion = new RepositorioMinutaAnotacion(new persistencia.AppContext());
            this._repoVigilante = new RepositorioVigilante(new persistencia.AppContext());
        }

        public void OnGet(int? minutaAnotacionId)
        {
            listaVigilante = _repoVigilante.GetAllVigilantes();

            if (minutaAnotacionId.HasValue)
            {
                minutaAnotacion = _repoMinutaAnotacion.GetMinutaAnotacion(minutaAnotacionId.Value);
            }
            else 
            {
                minutaAnotacion = new MinutaAnotacion();
            }
            if (minutaAnotacion == null)
            {
                RedirectToPage("./NotFound");
            }
                Page();  
        }

        public IActionResult OnPost(MinutaAnotacion minutaAnotacion, int vigilanteId)
        {
            if (ModelState.IsValid)
            {
                vigilante = _repoVigilante.GetVigilante(vigilanteId);
                if (minutaAnotacion.minutaAnotacionID > 0)
                {
                    minutaAnotacion.vigilante = vigilante;
                    minutaAnotacion = _repoMinutaAnotacion.UpdateMinutaAnotacion(minutaAnotacion);
                }
                else
                {
                    
                    minutaAnotacion = _repoMinutaAnotacion.AddMA(minutaAnotacion);
                    _repoMinutaAnotacion.AsignarVigilante(minutaAnotacion.minutaAnotacionID,vigilante.ID);
                }
                return RedirectToPage("/MinutaAnotaciones/ListarMinutas");

            }
            else
            {
               return Page();
            }
        }
    }
}
