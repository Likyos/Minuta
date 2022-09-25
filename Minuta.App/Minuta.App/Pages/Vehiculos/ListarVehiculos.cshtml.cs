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
    public class ListarVehiculosModel : PageModel
    {
        private readonly IRepositorioVehiculo _repoVehiculo;
        
        public IEnumerable<Vehiculo> listaVehiculo {get;set;} 

        public ListarVehiculosModel()
        {
            this._repoVehiculo = new RepositorioVehiculo(new persistencia.AppContext());
        }
        
        public void OnGet()
        {
            listaVehiculo = _repoVehiculo.GetAllVehiculos();
        }
    }
}
