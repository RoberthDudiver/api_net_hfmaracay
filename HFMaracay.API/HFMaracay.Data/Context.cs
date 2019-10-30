using HFMaracay.Data.ContextStrategy;
using HFMaracay.Entities;
using Microsoft.EntityFrameworkCore;


namespace HFMaracay.Data
{
    public class Context: StrategyContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<TipoLocalidades> TipoLocalidades { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Galeria> Galeria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }
    }
}
