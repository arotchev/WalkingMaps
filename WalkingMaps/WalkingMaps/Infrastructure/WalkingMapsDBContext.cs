using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WalkingMaps.Entities;

namespace WalkingMaps.Infrastructure
{
    public class WalkingMapsDBContext : IdentityDbContext<User>
    {
        public WalkingMapsDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Sight> Sights { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<WalkSight> WalkSights { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is needed to avoid problems with inheriting from  IdentityDbContext 
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            //WalkSights
            modelBuilder.Entity<WalkSight>().Property(s => s.WalkId).IsRequired();
            modelBuilder.Entity<WalkSight>().Property(s => s.SightId).IsRequired();
            modelBuilder.Entity<WalkSight>().Property(s => s.UserId).IsRequired();



            // Sights  
            modelBuilder.Entity<Sight>().Property(s => s.UserId).IsRequired();


            // Points        
            modelBuilder.Entity<Point>().Property(p => p.RouteId).IsRequired();

            // Routes         
            modelBuilder.Entity<Route>().Property(r => r.WalkId).IsRequired();
            modelBuilder.Entity<Route>().HasMany(w => w.Points).WithOne(s => s.Route);

            // Walks  
            modelBuilder.Entity<Walk>().Property(w => w.UserId).IsRequired();
        }      


    }
}
