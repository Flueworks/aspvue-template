#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using NodaTime.Extensions;
using School;
using School.Entity;

namespace Data
{
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public class TimestampInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var changeTracker = eventData.Context.ChangeTracker;
            var now = SystemClock.Instance.GetCurrentInstant();
            foreach (var created in changeTracker.Entries<ICreated>().Where(c => c.State == EntityState.Added))
            {
                created.Entity.Created = now;
            }

            foreach (var updated in changeTracker.Entries<IUpdated>().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added))
            {
                updated.Entity.Updated = now;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
