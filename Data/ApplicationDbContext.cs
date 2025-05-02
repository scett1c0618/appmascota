using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using appmascota.Models;

namespace appmascota.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mascota> DbSetMascota {get; set;}
    public DbSet<Adoptante> DbSetAdoptante {get; set;} 
    public DbSet<MascotaAdoptante> DbSetMascotaAdoptante {get; set;} 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

   
        modelBuilder.Entity<Mascota>()
            .HasOne(m => m.MascotaAdoptante)
            .WithOne(ma => ma.Mascota)
            .HasForeignKey<MascotaAdoptante>(ma => ma.MascotaId);

       
        modelBuilder.Entity<Adoptante>()
            .HasMany(a => a.MascotasAdoptadas)
            .WithOne(ma => ma.Adoptante)
            .HasForeignKey(ma => ma.AdoptanteId);

        
        modelBuilder.Entity<MascotaAdoptante>()
            .HasIndex(ma => ma.MascotaId)
            .IsUnique();
    }

}
