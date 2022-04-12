using AplicacionNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetMVC.Datos
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //Modelos
        public DbSet<Usuario> Usuario { get; set; }
    }
}
