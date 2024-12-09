using eCommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eCommerce.Infra.DataAccess;
public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly TimeProvider _timeProvider;

    public AuditableEntityInterceptor(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntity(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntity(DbContext? context)
    {
        if (context is null)
            return;

        var utcNow = _timeProvider.GetUtcNow();

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified)))
        {
            entry.Entity.UpdatedDate = utcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = utcNow; 
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedDate = utcNow;
                    break;
            }
        }

        return;
    }
}

/*
public class AuditoriaInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        var context = eventData.Context;

        if (context == null) return base.SavingChanges(eventData, result);

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCriacao").CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataAtualizacao").CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SavingChanges(eventData, result);
    }
}
*/