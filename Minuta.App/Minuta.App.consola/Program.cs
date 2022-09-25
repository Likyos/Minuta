using System;
using Minuta.App.persistencia;
using Minuta.App.dominio;

namespace Minuta.App.Consola
{
    class Program{
        private static IRepositorioVigilante _repoVigilante = new RepositorioVigilante(new persistencia.AppContext());
        private static IRepositorioResidente _repoResidente = new RepositorioResidente(new persistencia.AppContext());
        private static IRepositorioCorrespondencia _repoCorrespondencia = new RepositorioCorrespondencia(new persistencia.AppContext());
        private static IRepositorioVisitor _repoVisitor = new RepositorioVisitor(new persistencia.AppContext());
        private static IRepositorioVehiculo _repoVehiculo = new RepositorioVehiculo(new persistencia.AppContext());
        private static IRepositorioMinutaAnotacion _repoMA = new RepositorioMinutaAnotacion(new persistencia.AppContext());
        
        static void Main(string[] args)
        {
            
            //AddVigilante();
            //buscarPersona(1);
           //GetAllVigilantes();
           //AddVehiculo();
            //BuscarVehiculo(1);
           //BuscarVigilante(2);
           //AddCorrespondencia();
           //AddResidente();
           //AsignarResidente();
           //AddVisitor();
           //AddMA();
           //ListarMAs();
           //ListarResidentes();
           //ListarCorrespondencias();
           //ListarVigilantes();
           //ListarVehiculos();
           //ListarVisitors();
           //BuscarCorrespondencia(1);
           AsignarVigilante();
           Console.WriteLine("Hello, World!");
            
        }

        
        // agrgar persona//
        private static void AddVigilante(){

            var vigilante= new Vigilante{

                cedula= "1131",
                nombre = "Nasdta",
                apellido = "mencia",
                telefono = "1212",
                idUsuario = "admin",
                contrasena="admin",
                placaVigilante="11",             
                
            };
        _repoVigilante.AddVigilante(vigilante);
        }

        private static void AddResidente(){

            var residente= new Residente{

                cedula= "1010",
                nombre = "luis",
                apellido = "puertas",
                telefono = "1111",
                idUsuario = "admin",
                contrasena="admin",
                numApartamento =12, 
                estadoApartamento ="Ocupado", 
                estadoResidente = "Murio"       
                
            };

        _repoResidente.AddResidente(residente);

        }

        private static void AddCorrespondencia()
        {
            var correspondencia = new Correspondencia
            {
            tipoCorrespondencia ="Carta",
            remitente = "Aldo",
            estadoEntrega ="En recepcion"
            };
            _repoCorrespondencia.AddCorrespondencia(correspondencia);
        }

        private static void AddVehiculo(){

            var vehiculo= new Vehiculo{

                tipoVehiculo= "Carro",
                placaVehiculo = "ZXC123",
            };

        _repoVehiculo.AddVehiculo(vehiculo);
        }

        private static void AddVisitor(){

            var visitor= new Visitor{
                cedula= "131",
                nombre = "Panao",
                apellido = "Lopez",
                telefono = "1212",   
                motivoVisita = "Visitar apartamento12"
            };

        _repoVisitor.AddVisitor(visitor);
        }

        private static void AddMA(){

            var minutaAnotacion= new MinutaAnotacion{

            fechaAnotacion = new DateTime(2022, 02, 18),
            asunto = "Entro visitante al apartamento 2123"            
                
            };
        _repoMA.AddMA(minutaAnotacion);
        }

        private static void ListarMAs()
        {
            var minutaAnotaciones = _repoMA.GetAllMAs();
            foreach (MinutaAnotacion p in minutaAnotaciones)
            {
                Console.WriteLine(p.minutaAnotacionID + " " + p.fechaAnotacion + " " + p.asunto/* + " "+p.vigilante.ID*/);
            }        
        }

        private static void ListarResidentes()
        {
            var residentes = _repoResidente.GetAllResidentes();
            foreach (Residente p in residentes)
            {
                Console.WriteLine(p.ID +  " " + p.cedula +  " " + p.nombre + " " + p.apellido + " " + p.telefono +  " " + p.numApartamento +  " " + p.estadoApartamento);
            }        
        }

        private static void ListarCorrespondencias()
        {
            var correspondencias = _repoCorrespondencia.GetAllCorrespondencias();
            foreach (Correspondencia p in correspondencias)
            {
                Console.WriteLine(p.correspondenciaID +  " " + p.tipoCorrespondencia +  " " + p.remitente + " " + p.estadoEntrega);
            }        
        }

        private static void ListarVigilantes()
        {
            var vigilantes = _repoVigilante.GetAllVigilantes();
            foreach (Vigilante p in vigilantes)
            {
                Console.WriteLine(p.ID +  " " + p.nombre +  " " + p.apellido + " " + p.placaVigilante);
            }        
        }

        private static void ListarVehiculos()
        {
            var vehiculos = _repoVehiculo.GetAllVehiculos();
            foreach (Vehiculo p in vehiculos)
            {
                Console.WriteLine(p.vehiculoID +  " " + p.tipoVehiculo +  " " + p.placaVehiculo);
            }        
        }

        private static void ListarVisitors()
        {
            var visitors = _repoVisitor.GetAllVisitors();
            foreach (Visitor p in visitors)
            {
                Console.WriteLine(p.ID +  " " + p.cedula +  " " + p.nombre + " " + p.apellido + " " + p.motivoVisita);
            }        
        }
       
        private static void BuscarVigilante(int idVigilante)
        {
            var vigilante = _repoVigilante.GetVigilante(idVigilante);
            Console.WriteLine(vigilante.nombre+ " " + vigilante.placaVigilante);
        }       

        
        private static void BuscarVehiculo(int idVehiculo)
        {
            var vehiculo = _repoVehiculo.GetVehiculo(idVehiculo);
            Console.WriteLine(vehiculo.tipoVehiculo + " " + vehiculo.placaVehiculo);
        }

        private static void BuscarCorrespondencia(int idCorrespondencia)
        {
            var correspondencia = _repoCorrespondencia.GetCorrespondencia(idCorrespondencia);
            Console.WriteLine(correspondencia.tipoCorrespondencia+ " " + correspondencia.remitente);
        } 

        private static void AsignarResidente()
        {
            var Residente = _repoCorrespondencia.AsignarResidente(1, 2);
            Console.WriteLine(Residente.nombre + " " + Residente.apellido);
        }

        private static void AsignarVigilante()
        {
            var Vigilante = _repoMA.AsignarVigilante(1, 2);
            Console.WriteLine(Vigilante.nombre + " " + Vigilante.apellido);
        }
    }
}