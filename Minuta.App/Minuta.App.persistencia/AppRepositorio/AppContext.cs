using Microsoft.EntityFrameworkCore;
using Minuta.App.dominio;

namespace Minuta.App.persistencia
{
    public class AppContext : DbContext{
        public DbSet<Persona> Personas{get; set;}
        public DbSet<UserAdmin> UserAdmins{get; set;}
        public DbSet<Residente> Residentes{get; set;}
        public DbSet<Correspondencia> Correspondencias{get; set;}
        public DbSet<Vigilante> Vigilantes{get; set;}
        public DbSet<Visitor> Visitors{get; set;}
        public DbSet<MinutaAnotacion> MinutaAnotaciones{get; set;}
        public DbSet<Vehiculo> Vehiculos{get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Minuta");
            }
        }
    }
}
