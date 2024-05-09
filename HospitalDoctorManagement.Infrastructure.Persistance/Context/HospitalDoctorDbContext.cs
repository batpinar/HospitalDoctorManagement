using HospitalDoctorManagement.Api.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Infrastructure.Persistance.Context;

public class HospitalDoctorDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";
    public HospitalDoctorDbContext()
    {
        
    }

    public HospitalDoctorDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalDB;Persist Security Info=True";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<Hospital>()
        //    .HasMany(x => x.Doctors)
        //    .WithMany(x => x.Hospitals)
        //    .UsingEntity(j => j.ToTable("DoctorHospital"));

    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntities = ChangeTracker.Entries()
                                .Where(i => i.State == EntityState.Added)
                                .Select(i => (BaseEntity)i.Entity);
        PrepareAddedEntities(addedEntities);
    }

    private void PrepareAddedEntities(IEnumerable<BaseEntity> baseEntities)
    {
        foreach (var entity in baseEntities)
        {
            if (entity.CreateDate == DateTime.MinValue)
                entity.CreateDate = DateTime.Now;
        }
    }
}
