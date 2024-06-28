using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using Example.Common.DA.EF.MigrationsExtensions;
using Example.MultiTenantData.DA.Entities;

namespace Example.MultiTenantData.DA.EF;

internal sealed class MtDbContext : DbContext
{
    public const string SchemaName = "exmt";

    public MtDbContext(
        DbContextOptions<MtDbContext> options) : base(options)
    {
    }

    public DbSet<ReferenceEntity> RefereneceEntities { get; set; }
    public DbSet<SegregatedEntity> SegregatedEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.ReplaceService<IMigrationsSqlGenerator, MyMigrationsSqlGenerator>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);

        // Database does not pluralize table names
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetTableName(entityType.DisplayName());
        }

        modelBuilder.Entity<ReferenceEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.HasData(Entities.ReferenceEntities.GetAll());
        });

        modelBuilder.Entity<SegregatedEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.HasOne<ReferenceEntity>(e => e.ReferenceEntity).WithMany(e => e.SegregatedEntities).HasForeignKey(e => e.ReferenceEntityId);
            entity.HasData(Entities.SegregatedEntities.GetDefault());
        });
    }
}
