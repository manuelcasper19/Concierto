
using Microsoft.EntityFrameworkCore;
using Concierto.Shared.Entities;


namespace Concierto.API.Data
{   
    public class DataContext : DbContext
    {
        //Contructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //properties
        public DbSet<Tickets> Tickets { get; set; }

        //MethodS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
