using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo3
{
    public static class EnsureMigrationOrCreated
    {
        // use Migrate or EnsureCreated
        public static void EnsureCreatedOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            EnsureOfContext<T>(app, (context) => context.Database.EnsureCreated());
        }

        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            EnsureOfContext<T>(app, (context) => context.Database.Migrate());
        }

        private static void EnsureOfContext<T>(this IApplicationBuilder app, Action<T> action) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<T>();

                action(context);
            }
        }
    }
}
