using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server.Application.Common.Interfaces;
using Server.Domain.Entities.Common;
using Server.Domain.Entities.Documents;
using Server.Domain.Entities.Inventory;
using System.Linq.Expressions;

namespace Server.Infrastructure.Data.Context
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext // internal - sadece Infrastructure içinde erişilebilir
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Inventory Tables - Interface contract'ını sağlar
        public DbSet<Good> GOODS { get; set; }
        public DbSet<GoodsGroup> GOODS_GROUPS { get; set; }
        public DbSet<GoodsStock> GOODS_STOCK { get; set; }
        public DbSet<GoodsModification> GOODS_MODIFICATIONS { get; set; }
        public DbSet<GoodsUnit> GOODS_UNITS { get; set; }
        public DbSet<Storage> STORAGES { get; set; }

        // Document Tables
        public DbSet<Document> DOCUMENTS { get; set; }
        public DbSet<DocumentItem> DOCUMENT_ITEMS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity Configurations - Firebird spesifik ayarlar
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Global Query Filter - Soft Delete için
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(CreateIsDeletedFilter(entityType.ClrType));
                }
            }
        }

        // Soft Delete Expression Builder - IS_DELETED = false otomatik filtre
        private static LambdaExpression CreateIsDeletedFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var property = Expression.Property(parameter, "IS_DELETED");
            var condition = Expression.Equal(property, Expression.Constant(false));
            return Expression.Lambda(condition, parameter);
        }

        // Audit Trail - Yeni kayıtlara otomatik UID atama
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (string.IsNullOrEmpty(entry.Entity.UID))
                        {
                            entry.Entity.UID = Guid.CreateVersion7().ToString(); // Time-ordered GUID
                        }
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
